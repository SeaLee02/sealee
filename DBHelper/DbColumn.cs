namespace Sealee.T4Helper
{
    using System;

    public class DbColumn
    {
        /// <summary>
        /// 列ID
        /// </summary>
        public int ColumnID { get; set; }

        /// <summary>
        /// 是否为主键
        /// </summary>
        public bool IsPrimaryKey { get; set; }

        /// <summary>
        /// 列名称
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 列类型
        /// </summary>
        public string ColumnType { get; set; }

        /// <summary>
        /// c#类型
        /// </summary>
        public string CShareType => SqlServerDbTypeMap.MapCsharpType(ColumnType);

        /// <summary>
        /// 基类
        /// </summary>              
        public Type CommonType => SqlServerDbTypeMap.MapCommonType(ColumnType);

        /// <summary>
        /// 是否为自增长
        /// </summary>
        public bool IsIdentity { get; set; }

        /// <summary>
        /// 是否为空
        /// </summary>
        public bool IsNullable { get; set; }

        /// <summary>
        /// 字节长度
        /// </summary>                      
        public int ByteLength { get; set; }

        /// <summary>
        /// 字符长度
        /// </summary>
        public int CharLength { get; set; }

        /// <summary>
        /// 列描述
        /// </summary>
        public string ColumnDesc { get; set; }

        public int Precision { get; set; }

        public int Scale { get; set; }

        /// <summary>
        /// 表明
        /// </summary>
        public string TableName { get; set; }

    }
}
