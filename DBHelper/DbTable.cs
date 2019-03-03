namespace Sealee.T4Helper
{
    using System.Collections.Generic;

    public sealed class DbTable
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        ///  架构名
        /// </summary>
        public string Schemname { get; set; }

        /// <summary>
        /// 行数
        /// </summary>
        public int Rows { get; set; }

        /// <summary>
        /// 是否拥有主键
        /// </summary>
        public bool HasPrimaryKey { get; set; }

        /// <summary>
        /// 表描述
        /// </summary>
        public string TableDesc { get; set; }

        /// <summary>
        /// 主键名
        /// </summary>
        public string TablePrimarkeyName { get; set; }

        /// <summary>
        /// 主键类型
        /// </summary>
        public string TablePrimarkeyType { get; set; }      

        public List<DbColumn> DbColumns { get; set; }

        /// <summary>
        /// 枚举字符串集合
        /// </summary>
        public List<string> ListEnumStr { get; set; }

        public DbTable()
        {
            ListEnumStr = new List<string>();
        }
    }
}
