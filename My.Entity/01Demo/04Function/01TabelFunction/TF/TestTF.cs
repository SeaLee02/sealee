namespace Test.T4
{
    using System.Collections.Generic;
    using System;
    using Sealee.SqlHelper;

	/// <summary>
    /// 
    /// </summary>
    public class TestTF 
    {
        
        /// <summary>
        /// 
        /// </summary>
        public int @id { get; set; } 

         /// <summary>
        /// 获取List集合
        /// </summary>
        /// <returns>list集合</returns>
        public List<TestTFTableInfo> QueryList()
        {
            var conStr ="";
            string sql = this.GetSql();
            return DBHelper.QueryList<TestTFTableInfo>(conStr, sql, null);
        }

        public string GetSql()
        {
            string sql = "SELECT dbo.TestTF(";
            sql += $"'{this.@id}',";
            sql = sql.Substring(0, sql.Length - 1);
            sql+=");";
            return sql;
        }


	}

    public class  TestTFTableInfo
    {
    
        
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; } 
        
        /// <summary>
        /// 
        /// </summary>
        public bool sex { get; set; } 
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime time { get; set; } 

    }

}
