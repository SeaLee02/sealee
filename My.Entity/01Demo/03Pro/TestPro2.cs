namespace My.Entity.Demo.Pro
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using My.Entity.Framework._03Pro;
    
     /// <summary>
    /// 
    /// </summary>
    public class TestPro2 : BasePro
    {
	        
        /// <summary>
        /// 
        /// </summary>
        public int @i { get; set; } 
        
        /// <summary>
        /// 
        /// </summary>
        public int @I2 { get; set; } 
                                               
        public override SqlParameter[] GetSqlParameters()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@i", this.i));
            var paramI2 = new SqlParameter("@I2", SqlDbType.Int);
            paramI2.Direction = ParameterDirection.Output;
            parameters.Add(paramI2);
            return parameters.ToArray();
         }

        public override string GetSql()
        {
            string sql = "EXEC dbo.TestPro2 ";
            sql += " @i =@i,";
            sql += " @I2 =@I2 OUT,";
            sql = sql.Substring(0, sql.Length - 1);
            return sql;
        }

	}
}
