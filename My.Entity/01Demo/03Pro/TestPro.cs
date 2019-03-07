namespace Test.T4
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using My.Entity.Framework._03Pro;
    
     /// <summary>
    /// 
    /// </summary>
    public class TestPro : BasePro
    {
	        
        /// <summary>
        /// 
        /// </summary>
        public int @i { get; set; } 
                                               
        public override SqlParameter[] GetSqlParameters()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@i", this.i));
            return parameters.ToArray();
         }

        public override string GetSql()
        {
            string sql = "EXEC dbo.TestPro ";
            sql += " @i =@i,";
            sql = sql.Substring(0, sql.Length - 1);
            return sql;
        }

	}
}
