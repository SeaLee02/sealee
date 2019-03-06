namespace Sealee.T4Helper
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class DbUtil
    {

        /// <summary>
        /// 获取表信息
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="tables"></param>
        /// <returns></returns>
        public static List<DbTable> GetDbTables(string connectionString, string tables = "")
        {
            //查询条件，如果包含,就是要in,否则就是要like查询
            if (!string.IsNullOrEmpty(tables))
            {
                tables = ((!tables.Contains(",")) ? $" AND  obj.name like '{tables}%'  " : string.Format(" and obj.name in ('{0}')", tables.Replace(",", "','")));
            }
            string sql = $@"
                                SELECT obj.name Tablename,
                                       schem.name Schemname,
                                       idx.rows,
                                       CAST(CASE
                                                WHEN
                                                (
                                                    SELECT COUNT(1)
                                                    FROM sys.indexes
                                                    WHERE object_id = obj.object_id
                                                          AND is_primary_key = 1
                                                ) >= 1 THEN
                                                    1
                                                ELSE
                                                    0
                                            END AS BIT) HasPrimaryKey,
                                        b.value  TableDesc,
                                        t.*
                                FROM sys.objects obj
                                    INNER JOIN sysindexes idx   --行数
                                        ON obj.object_id = idx.id
                                           AND idx.indid <= 1
                                    INNER JOIN sys.schemas schem   --架构
                                        ON obj.schema_id = schem.schema_id
                                    LEFT JOIN sys.extended_properties b  --描述
                                        ON obj.object_id = b.major_id
                                           AND b.minor_id = 0
                                    OUTER APPLY  --主键名称和类型
                                (
                                    SELECT TOP 1
                                           colm.name AS TablePrimarkeyName,
                                           systype.name AS TablePrimarkeyType
                                    FROM sys.columns colm
                                        INNER JOIN sys.types systype
                                            ON colm.system_type_id = systype.system_type_id
                                    WHERE colm.object_id = obj.object_id
                                          AND colm.column_id IN (
                                                                    SELECT ic.column_id
                                                                    FROM sys.indexes idx
                                                                        INNER JOIN sys.index_columns ic
                                                                            ON idx.index_id = ic.index_id
                                                                               AND idx.object_id = ic.object_id
                                                                    WHERE idx.object_id = obj.object_id
                                                                          AND idx.is_primary_key = 1
                                                                )
                                ) t
                                WHERE obj.type = 'U' {tables}   
                                ORDER BY obj.name";

            DataTable dataTable = GetDataTable(connectionString, sql);
            //List<DbTable> list = dataTable.Rows.Cast<DataRow>().Select(row => new DbTable
            //{
            //    TableName = row.Field<string>("Tablename"),
            //    Schemname = row.Field<string>("Schemname"),
            //    TableDesc = row.Field<string>("TableDesc") ?? "",
            //    Rows = row.Field<int>("rows"),
            //    HasPrimaryKey = row.Field<bool>("HasPrimaryKey"),
            //    TablePrimarkeyName = row.Field<string>("TablePrimarkeyName") ?? "",
            //    TablePrimarkeyType = row.Field<string>("TablePrimarkeyType") ?? "",
            //    DbColumns = GetDbColumns(connectionString, row.Field<string>("Tablename"),)
            //}).ToList();

            List<DbTable> list = new List<DbTable>();
            foreach (DataRow row in dataTable.Rows)
            {
                DbTable table = new DbTable
                {
                    TableName = row.Field<string>("Tablename"),
                    Schemname = row.Field<string>("Schemname"),
                    TableDesc = row.Field<string>("TableDesc") ?? "",
                    Rows = row.Field<int>("rows"),
                    HasPrimaryKey = row.Field<bool>("HasPrimaryKey"),
                    TablePrimarkeyName = row.Field<string>("TablePrimarkeyName") ?? "",
                    TablePrimarkeyType = row.Field<string>("TablePrimarkeyType") ?? ""
                };
                table.DbColumns = GetDbColumns(connectionString, row.Field<string>("Tablename"), table);
                list.Add(table);
            }
            return list;
        }

        /// <summary>
        /// 获取列信息
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static List<DbColumn> GetDbColumns(string connectionString, string tableName, DbTable table)
        {
            string sql = $@"WITH indexCTE
                            AS (SELECT ic.column_id,
                                       ic.index_column_id,
                                       ic.object_id
                                FROM sys.indexes idx
                                    INNER JOIN sys.index_columns ic
                                        ON idx.index_id = ic.index_id
                                           AND idx.object_id = ic.object_id
                                WHERE idx.object_id = OBJECT_ID('{tableName}')   --找到该表的主键信息
                                      AND idx.is_primary_key = 1)
                            SELECT colm.column_id ColumnID,                 --列id
                                   CAST(CASE
                                            WHEN indexCTE.column_id IS NULL THEN
                                                0
                                            ELSE
                                                1
                                        END AS BIT) IsPrimaryKey,
                                   colm.name ColumnName,                    --列名称
                                   systype.name ColumnType,                 --列类型
                                   colm.is_identity IsIdentity,             --是否自增长
                                   colm.is_nullable IsNullable,             --是否为空
                                   CAST(colm.max_length AS INT) ByteLength, -- sys.columns中的max_length是字节
                                   (CASE
                                        WHEN systype.name = 'nvarchar'
                                             AND colm.max_length > 0 THEN
                                            colm.max_length / 2
                                        WHEN systype.name = 'nchar'
                                             AND colm.max_length > 0 THEN
                                            colm.max_length / 2
                                        WHEN systype.name = 'ntext'
                                             AND colm.max_length > 0 THEN
                                            colm.max_length / 2
                                        ELSE
                                            colm.max_length
                                    END
                                   ) CharLength,                            --得到字符类型长度
                                   CAST(colm.precision AS INT) Precision,
                                   CAST(colm.scale AS INT) Scale,
                                   sep.value ColumnDesc  --列描述
                            FROM sys.columns colm
                                INNER JOIN sys.types systype  
                                    ON colm.system_type_id = systype.system_type_id
                                       AND systype.user_type_id = colm.user_type_id   --通过两个关联进行过滤得到用户创建的类型
                                LEFT JOIN sys.extended_properties sep   
                                    ON sep.major_id = colm.object_id  --得到是这个表的
                                       AND colm.column_id = sep.minor_id   --这列的
                                LEFT JOIN indexCTE
                                    ON indexCTE.column_id = colm.column_id
                                       AND indexCTE.object_id = colm.object_id 
                            WHERE colm.object_id = OBJECT_ID('{tableName}')";
            DataTable dataTable = GetDataTable(connectionString, sql);
            List<DbColumn> list = new List<DbColumn>();
            foreach (DataRow row in dataTable.Rows)
            {
                DbColumn column = new DbColumn
                {
                    ColumnID = row.Field<int>("ColumnID"),
                    IsPrimaryKey = row.Field<bool>("IsPrimaryKey"),
                    ColumnName = row.Field<string>("ColumnName"),
                    ColumnType = row.Field<string>("ColumnType"),
                    ByteLength = row.Field<int>("ByteLength"),
                    CharLength = row.Field<int>("CharLength"),
                    IsIdentity = row.Field<bool>("IsIdentity"),
                    IsNullable = row.Field<bool>("IsNullable"),
                    Precision = row.Field<int>("Precision"),
                    Scale = row.Field<int>("Scale"),
                    ColumnDesc = row.Field<string>("ColumnDesc") ?? "",
                    TableName = tableName
                };
                string enumStr = GetEnumStr(column.ColumnDesc, column.ColumnName, table);
                if (!string.IsNullOrEmpty(enumStr))
                {                                 
                    column.ColumnType = enumStr;
                }
                list.Add(column);

            }
            return list;
        }

        /// <summary>
        /// 获取列信息,视图
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static List<DbColumn> GetDbColumns(string connectionString, string tableName)
        {
            string sql = $@"WITH indexCTE
                            AS (SELECT ic.column_id,
                                       ic.index_column_id,
                                       ic.object_id
                                FROM sys.indexes idx
                                    INNER JOIN sys.index_columns ic
                                        ON idx.index_id = ic.index_id
                                           AND idx.object_id = ic.object_id
                                WHERE idx.object_id = OBJECT_ID('{tableName}')   --找到该表的主键信息
                                      AND idx.is_primary_key = 1)
                            SELECT colm.column_id ColumnID,                 --列id
                                   CAST(CASE
                                            WHEN indexCTE.column_id IS NULL THEN
                                                0
                                            ELSE
                                                1
                                        END AS BIT) IsPrimaryKey,
                                   colm.name ColumnName,                    --列名称
                                   systype.name ColumnType,                 --列类型
                                   colm.is_identity IsIdentity,             --是否自增长
                                   colm.is_nullable IsNullable,             --是否为空
                                   CAST(colm.max_length AS INT) ByteLength, -- sys.columns中的max_length是字节
                                   (CASE
                                        WHEN systype.name = 'nvarchar'
                                             AND colm.max_length > 0 THEN
                                            colm.max_length / 2
                                        WHEN systype.name = 'nchar'
                                             AND colm.max_length > 0 THEN
                                            colm.max_length / 2
                                        WHEN systype.name = 'ntext'
                                             AND colm.max_length > 0 THEN
                                            colm.max_length / 2
                                        ELSE
                                            colm.max_length
                                    END
                                   ) CharLength,                            --得到字符类型长度
                                   CAST(colm.precision AS INT) Precision,
                                   CAST(colm.scale AS INT) Scale,
                                   sep.value ColumnDesc  --列描述
                            FROM sys.columns colm
                                INNER JOIN sys.types systype  
                                    ON colm.system_type_id = systype.system_type_id
                                       AND systype.user_type_id = colm.user_type_id   --通过两个关联进行过滤得到用户创建的类型
                                LEFT JOIN sys.extended_properties sep   
                                    ON sep.major_id = colm.object_id  --得到是这个表的
                                       AND colm.column_id = sep.minor_id   --这列的
                                LEFT JOIN indexCTE
                                    ON indexCTE.column_id = colm.column_id
                                       AND indexCTE.object_id = colm.object_id 
                            WHERE colm.object_id = OBJECT_ID('{tableName}')";
            DataTable dataTable = GetDataTable(connectionString, sql);
            List<DbColumn> list = new List<DbColumn>();
            foreach (DataRow row in dataTable.Rows)
            {
                DbColumn column = new DbColumn
                {
                    ColumnID = row.Field<int>("ColumnID"),
                    IsPrimaryKey = row.Field<bool>("IsPrimaryKey"),
                    ColumnName = row.Field<string>("ColumnName"),
                    ColumnType = row.Field<string>("ColumnType"),
                    ByteLength = row.Field<int>("ByteLength"),
                    CharLength = row.Field<int>("CharLength"),
                    IsIdentity = row.Field<bool>("IsIdentity"),
                    IsNullable = row.Field<bool>("IsNullable"),
                    Precision = row.Field<int>("Precision"),
                    Scale = row.Field<int>("Scale"),
                    ColumnDesc = row.Field<string>("ColumnDesc") ?? "",
                    TableName = tableName
                };              
                list.Add(column);

            }
            return list;
        }

        /// <summary>
        /// 获取枚举字符串
        /// </summary>
        /// <param name="columnDesc"></param>
        /// <param name="colName"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        private static string GetEnumStr(string columnDesc, string colName, DbTable table)
        {
            string regex = @"(?<=枚举).*";
            if (Regex.IsMatch(columnDesc, regex))
            {
                //枚举定义规则: xxxm枚举(value.key[Des];) 
                // 枚举结尾,()中是枚举定义,[]中是描述值可有可无, .分割值和key,  ;分割每个定义
                string enumString = columnDesc;
                // "测试枚举(7.Sunday[星期天];1.Monday[星期一];2.Tuesday[星期二];3.Wednesday[];5.Friday)";
                string math = Regex.Match(enumString, regex).Value; //得到枚举字符串，带()
                string text = math.Replace("(", "").Replace(")", ""); //去除()
                string one = "    ";  //一级空格
                string two = "        "; //二级空格
                string enumName = colName + "Enum";
                StringBuilder enumSb = new StringBuilder();
                //拼接头部
                enumSb.AppendLine($"{one}/// <summary>");
                enumSb.AppendLine($"{one}/// {columnDesc}");
                enumSb.AppendLine($"{one}/// </summary>");
                enumSb.AppendLine($"{one}public enum {enumName}");
                enumSb.AppendLine($"{one}{{");
                int i = 1;
                string[] arry = text.Split(';');
                foreach (string item in arry)
                {
                    if (item.Contains("[") && item.Contains("]"))  //是否包含描述
                    {
                        string[] arry3 = item.Split('[');
                        string[] arry2 = arry3[0].Split('.');
                        //拼接枚举值
                        enumSb.AppendLine($"{two}/// <summary>");
                        enumSb.AppendLine($"{two}/// {arry2[1]}");
                        enumSb.AppendLine($"{two}/// </summary>");
                        enumSb.AppendLine($"{two}[Description(\"{arry3[1].Replace("]", "")}\")]");
                        if (i == arry.Length)  //最后一个不带,
                        {
                            enumSb.AppendLine($"{two}{arry2[1]} = {arry2[0]}");
                        }
                        else   //带,
                        {
                            enumSb.AppendLine($"{two}{arry2[1]} = {arry2[0]},");
                        }
                        enumSb.AppendLine("");

                    }
                    else
                    {
                        string[] arry2 = item.Split('.');
                        enumSb.AppendLine($"{two}/// <summary>");
                        enumSb.AppendLine($"{two}/// {arry2[1]}");
                        enumSb.AppendLine($"{two}/// </summary>");
                        if (i == arry.Length)
                        {
                            enumSb.AppendLine($"{two}{arry2[1]} = {arry2[0]}");
                        }
                        else
                        {
                            enumSb.AppendLine($"{two}{arry2[1]} = {arry2[0]},");
                        }
                        enumSb.AppendLine("");
                    }

                    i++;
                }
                enumSb.AppendLine($"{one}}}");
                table.ListEnumStr.Add(enumSb.ToString());
                return enumName;
            }
            return string.Empty;

        }

        /// <summary>
        /// 获取视图信息
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="viewName"></param>
        /// <returns></returns>
        public static List<DbView> GetDbView(string connectionString, string viewName)
        {
            if (!string.IsNullOrEmpty(viewName))
            {
                viewName = ((!viewName.Contains(",")) ? $" AND  obj.name like '{viewName}%'  " : string.Format(" and obj.name in ('{0}')", viewName.Replace(",", "','")));
            }
            string sql = $@"SELECT obj.name ViewName,
                           se.value    ViewDesc
                            FROM sys.objects obj
                                LEFT JOIN[sys].[extended_properties] se
                                   ON obj.object_id = se.major_id
                                      AND se.minor_id = 0
                            WHERE obj.type = 'V'  {viewName} ";

            DataTable dataTable = GetDataTable(connectionString, sql);
            List<DbView> list = dataTable.Rows.Cast<DataRow>().Select(row => new DbView
            {
                ViewName = row.Field<string>("ViewName"),
                ViewDesc = row.Field<string>("ViewDesc") ?? "",
                DbColumns = GetDbColumns(connectionString, row.Field<string>("ViewName"))
            }).ToList();
            return list;

        }

        /// <summary>
        /// 存储过程，表值函数，标量函数
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="objName">对象名称</param>
        /// <param name="xtype">默认为P存储过程， --FN:标量,TF:表值,P:存储过程</param>
        /// <returns></returns>
        public static List<DbObj> GetDbObj(string connectionString, string objName, string xtype = "P")
        {
            if (!string.IsNullOrEmpty(objName))
            {
                objName = ((!objName.Contains(",")) ? $" AND  obj.name like '{objName}%'  " : string.Format(" and obj.name in ('{0}')", objName.Replace(",", "','")));
            }
            string sql = $@"SELECT obj.name ViewName,
                           se.value    ViewDesc
                            FROM sys.objects obj
                                LEFT JOIN[sys].[extended_properties] se
                                   ON obj.object_id = se.major_id
                                      AND se.minor_id = 0
                            WHERE obj.type ='{xtype}'  {objName} ";

            DataTable dataTable = GetDataTable(connectionString, sql);
            List<DbObj> list = dataTable.Rows.Cast<DataRow>().Select(row => new DbObj
            {
                ObjName = row.Field<string>("ViewName"),
                ObjDesc = row.Field<string>("ViewDesc") ?? "",
                DbObjColumns = GetDbObjColumns(connectionString, row.Field<string>("ViewName"))
            }).ToList();
            return list;
        }

        /// <summary>
        /// 获取对象的列信息
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="objName">对象名</param>
        /// <returns></returns>
        public static List<DbObjColumn> GetDbObjColumns(string connectionString, string objName)
        {
            string sql = $@"
                                SELECT sp.name ParameterName,
                           obj.name ObjName,
	                       systype.name ObjType,
	                       sp.is_output IsOutPut,
                           CAST(sp.max_length AS INT) ByteLength, -- sys.columns中的max_length是字节
                           (CASE
                                WHEN systype.name = 'nvarchar'
                                     AND sp.max_length > 0 THEN
                                    sp.max_length / 2
                                WHEN systype.name = 'nchar'
                                     AND sp.max_length > 0 THEN
                                    sp.max_length / 2
                                WHEN systype.name = 'ntext'
                                     AND sp.max_length > 0 THEN
                                    sp.max_length / 2
                                ELSE
                                    sp.max_length
                            END
                           ) CharLength,
                           CAST(sp.precision AS INT) Precision,
                           CAST(sp.scale AS INT) Scale,
                           sep.value ColumnDesc
                    FROM sys.parameters sp
                        LEFT JOIN sys.objects obj
                            ON sp.object_id = obj.object_id
           
                        INNER JOIN sys.types systype
                            ON sp.system_type_id = systype.system_type_id
                               AND systype.user_type_id = sp.user_type_id
                        LEFT JOIN sys.extended_properties sep
                            ON sep.major_id = sp.object_id --得到是这个表的
                               AND sp.parameter_id = sep.minor_id --这列的
                    WHERE sp.parameter_id != 0 AND obj.name='{objName}'
                ";
            DataTable dataTable = GetDataTable(connectionString, sql);
            List<DbObjColumn> list = dataTable.Rows.Cast<DataRow>().Select(row => new DbObjColumn
            {
                ObjColumnName = row.Field<string>("ParameterName"),
                ObjColumnType = row.Field<string>("ObjType"),
                ByteLength = row.Field<int>("ByteLength"),
                CharLength = row.Field<int>("CharLength"),
                Precision = row.Field<int>("Precision"),
                Scale = row.Field<int>("Scale"),
                ObjColumnDesc = row.Field<string>("ColumnDesc") ?? "",
                ObjName = objName,
                IsOutPut = row.Field<bool>("IsOutPut")
            }).ToList();
            return list;
        }

        #region 执行sql获取DataTable   
        /// <summary>
        /// 执行Sql语句获取DataTable
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandText"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string connectionString, string commandText, params SqlParameter[] parms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = commandText;
                command.Parameters.AddRange(parms);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
        #endregion
    }
}
