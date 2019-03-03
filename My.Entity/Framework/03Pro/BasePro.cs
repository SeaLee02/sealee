namespace My.Entity.Framework._03Pro
{
    using System.Data.SqlClient;

    /// <summary>
    /// 存储过程的父类
    /// </summary>
    public abstract class BasePro
    {

        


        /// <summary>
        /// 获取参数集合
        /// </summary>
        /// <returns></returns>
        public abstract SqlParameter[] GetSqlParameters();

        /// <summary>
        /// 获取sql语句
        /// </summary>
        /// <returns></returns>
        public abstract string GetSql();
    }
}
