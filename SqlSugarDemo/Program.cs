using Modle;
using Sealee.Util;
using SqlSugar;
using SqlSugarDemo.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SqlSugarDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContext dbContext = new DbContext();
            //Standard model = new Standard();
            //model.Description = "添加描述";
            //model.Standardname = "性能";
            //dbContext.Standards.Insert(model);

            var dd123 = dbContext.Testdemos.GetList();

            Testdemo testdemo = new Testdemo();
            testdemo.Name = "记得记得就";
            testdemo.Testenums = TestEnum.Sealee;
            dbContext.Testdemos.Insert(testdemo);

            int i = 5;
            if (i == 4)
            {
                using (SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = @"server=PV-X00273458\SQLEXPRESS;uid=sa;pwd=123;database=SchoolDB",
                    DbType = DbType.SqlServer,
                    IsAutoCloseConnection = true,
                    InitKeyType = InitKeyType.Attribute
                }))
                {
                    List<DbTableInfo> list = db.DbMaintenance.GetTableInfoList();
                    List<DbTableInfo> viewList = db.DbMaintenance.GetViewInfoList();
                    //表
                    foreach (DbTableInfo table in list)
                    {
                        string table_name = table.Name.ToCase();
                        db.MappingTables.Add(table_name, table.Name);
                        List<DbColumnInfo> dd = db.DbMaintenance.GetColumnInfosByTableName(table.Name);
                        foreach (DbColumnInfo item in dd)
                        {
                            db.MappingColumns.Add(item.DbColumnName.ToCase(), item.DbColumnName, table_name);
                        }
                        db.DbFirst.IsCreateAttribute().Where(table.Name).CreateClassFile("E:\\Code\\sealee\\SqlSugar\\Model3", "Modle2");
                    }
                    //视图
                    foreach (DbTableInfo table in viewList)
                    {
                        string table_name = table.Name.ToCase();
                        db.MappingTables.Add(table_name, table.Name);
                        List<DbColumnInfo> dd = db.DbMaintenance.GetColumnInfosByTableName(table.Name);
                        foreach (DbColumnInfo item in dd)
                        {
                            db.MappingColumns.Add(item.DbColumnName.ToCase(), item.DbColumnName, table_name);

                        }
                        db.DbFirst.IsCreateAttribute().Where(table.Name).CreateClassFile("E:\\Code\\sealee\\SqlSugar\\Model3", "Modle2");
                    }
                }

            }


            #region Oacle
            if (i == 1)
            {
                using (SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = "Data Source = 数据库地址:端口号/数据库名; User ID = 用户id; Password = 用户密码; ",
                    DbType = DbType.Oracle,
                    IsAutoCloseConnection = true,
                    InitKeyType = InitKeyType.Attribute
                }))
                {
                    ////单个实体
                    //var d = "View_DEE_SUM(SY.DD)";
                    //string aa = d.ToCase();
                    //db.MappingTables.Add("ClassStudent", "DEMO_STUDENT");
                    //db.MappingColumns.Add("NewId", "ID", "ClassStudent");
                    //db.MappingColumns.Add("StudentName", "STUDENTNAME", "ClassStudent");
                    //db.DbFirst.IsCreateAttribute().Where("DEMO_STUDENT").CreateClassFile(@"", "Model");


                    List<DbTableInfo> list = db.DbMaintenance.GetTableInfoList();
                    List<DbTableInfo> viewList = db.DbMaintenance.GetViewInfoList();
                    //表
                    foreach (DbTableInfo table in list)
                    {
                        string table_name = table.Name.ToCase();
                        db.MappingTables.Add(table_name, table.Name);
                        List<DbColumnInfo> dd = db.DbMaintenance.GetColumnInfosByTableName(table.Name);
                        foreach (DbColumnInfo item in dd)
                        {
                            db.MappingColumns.Add(item.DbColumnName.ToCase(), item.DbColumnName, table_name);

                        }
                        db.DbFirst.IsCreateAttribute().Where(table.Name).CreateClassFile(@"", "Model");
                    }
                    //视图
                    foreach (DbTableInfo table in viewList)
                    {
                        string table_name = table.Name.ToCase();
                        db.MappingTables.Add(table_name, table.Name);
                        List<DbColumnInfo> dd = db.DbMaintenance.GetColumnInfosByTableName(table.Name);
                        foreach (DbColumnInfo item in dd)
                        {
                            db.MappingColumns.Add(item.DbColumnName.ToCase(), item.DbColumnName, table_name);

                        }
                        db.DbFirst.IsCreateAttribute().Where(table.Name).CreateClassFile(@"", "Model");
                    }
                }
            }
            #endregion
            #region Mysql
            if (i == 2)
            {
                using (SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = "server=localhost;uid=root;pwd=123;database=performace2; ",
                    DbType = DbType.MySql,
                    IsAutoCloseConnection = true,
                    InitKeyType = InitKeyType.Attribute
                }))
                {
                    List<DbTableInfo> list = db.DbMaintenance.GetTableInfoList();
                    List<DbTableInfo> viewList = db.DbMaintenance.GetViewInfoList();
                    //表
                    foreach (DbTableInfo table in list)
                    {
                        string table_name = table.Name.ToCase();
                        db.MappingTables.Add(table_name, table.Name);
                        List<DbColumnInfo> dd = db.DbMaintenance.GetColumnInfosByTableName(table.Name);
                        foreach (DbColumnInfo item in dd)
                        {
                            db.MappingColumns.Add(item.DbColumnName.ToCase(), item.DbColumnName, table_name);

                        }
                        db.DbFirst.IsCreateAttribute().Where(table.Name).CreateClassFile(@"", "ModelMySql_M");
                    }
                    //视图
                    foreach (DbTableInfo table in viewList)
                    {
                        string table_name = table.Name.ToCase();
                        db.MappingTables.Add(table_name, table.Name);
                        List<DbColumnInfo> dd = db.DbMaintenance.GetColumnInfosByTableName(table.Name);
                        foreach (DbColumnInfo item in dd)
                        {
                            db.MappingColumns.Add(item.DbColumnName.ToCase(), item.DbColumnName, table_name);

                        }
                        db.DbFirst.IsCreateAttribute().Where(table.Name).CreateClassFile(@"", "Model_M");
                    }
                }
            }

            if (i == 2)
            {
                using (SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = "server=localhost;uid=root;pwd=123;database=jxkh; ",
                    DbType = DbType.MySql,
                    IsAutoCloseConnection = true,
                    InitKeyType = InitKeyType.Attribute
                }))
                {
                    List<DbTableInfo> list = db.DbMaintenance.GetTableInfoList();
                    List<DbTableInfo> viewList = db.DbMaintenance.GetViewInfoList();
                    //表
                    foreach (DbTableInfo table in list)
                    {
                        string table_name = table.Name.ToCase();
                        db.MappingTables.Add(table_name, table.Name);
                        List<DbColumnInfo> dd = db.DbMaintenance.GetColumnInfosByTableName(table.Name);
                        foreach (DbColumnInfo item in dd)
                        {
                            db.MappingColumns.Add(item.DbColumnName.ToCase(), item.DbColumnName, table_name);

                        }
                        db.DbFirst.IsCreateAttribute().Where(table.Name).CreateClassFile(@"", "Model_J");
                    }
                    //视图
                    foreach (DbTableInfo table in viewList)
                    {
                        string table_name = table.Name.ToCase();
                        db.MappingTables.Add(table_name, table.Name);
                        List<DbColumnInfo> dd = db.DbMaintenance.GetColumnInfosByTableName(table.Name);
                        foreach (DbColumnInfo item in dd)
                        {
                            db.MappingColumns.Add(item.DbColumnName.ToCase(), item.DbColumnName, table_name);

                        }
                        db.DbFirst.IsCreateAttribute().Where(table.Name).CreateClassFile(@"", "Model_J");
                    }
                }
            }
            #endregion



        }
    }
}
