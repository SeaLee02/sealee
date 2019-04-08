namespace My.Entity.Demo.Function
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;      
    using Sealee.SqlHelper;

	/// <summary>
    /// 
    /// </summary>
    public class TestBZ 
    {
        
        /// <summary>
        /// 
        /// </summary>
        public string @name { get; set; } 

         /// <summary>
        /// 获取单个值
        /// </summary>
        /// <typeparam name="T">值得类型</typeparam>
        /// <returns>单个值</returns>
        public T ExecuteScalar<T>()
        {
            var conStr = "";
            string sql = this.GetSql();
            return DBHelper.ExecuteScalar<T>(conStr, sql, null);
        }

        public string GetSql()
        {
            string sql = "SELECT dbo.TestBZ(";
            sql += $"'{this.@name}',";
            sql = sql.Substring(0, sql.Length - 1);
            sql+=");";
            return sql;
        }

	}
}
