namespace My.Entity.Demo.Pro
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using My.Entity.Framework._03Pro;
    
     /// <summary>
    /// 
    /// </summary>
    public class TestPro3 : BasePro
    {
	        
        /// <summary>
        /// 
        /// </summary>
        public int @id { get; set; } 
                                               
        public override SqlParameter[] GetSqlParameters()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id", this.id));
            return parameters.ToArray();
         }

        public override string GetSql()
        {
            string sql = "EXEC dbo.TestPro3 ";
            sql += " @id =@id,";
            sql = sql.Substring(0, sql.Length - 1);
            return sql;
        }

	}
}
