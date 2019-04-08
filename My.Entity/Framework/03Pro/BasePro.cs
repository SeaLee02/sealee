namespace My.Entity.Framework._03Pro
{
    using Sealee.SqlHelper;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// 存储过程的父类
    /// </summary>
    public abstract class BasePro
    {

        /// <summary>
        /// 获取List集合
        /// </summary>
        /// <param name="outObjs">输出的参数集合</param>
        /// <typeparam name="T">类型</typeparam>
        /// <returns>list集合</returns>
        public virtual List<T> QueryList<T>(Dictionary<string, object> outObjs = null)
            where T : class, new()
        {
            string conStr = "";
            string sql = this.GetSql();
            SqlParameter[] parameters = this.GetSqlParameters();
            return DBHelper.QueryList<T>(conStr, sql, outObjs, parameters);
        }

        /// <summary>
        /// 获取单个值
        /// </summary>
        /// <param name="outObjs">输出的参数集合</param>
        /// <typeparam name="T">值得类型</typeparam>
        /// <returns>单个值</returns>
        public virtual T ExecuteScalar<T>(Dictionary<string, object> outObjs = null)
        {
            string conStr ="";
            string sql = this.GetSql();
            SqlParameter[] parameters = this.GetSqlParameters();
            return DBHelper.ExecuteScalar<T>(conStr, sql, outObjs, parameters);
        }

        /// <summary>
        /// 执行获取影响的行数
        /// </summary>
        /// <param name="outObjs">输出的参数集合</param>
        /// <returns>单个值</returns>
        public virtual int ExecuteNonQuery(Dictionary<string, object> outObjs = null)
        {
            string conStr = "";
            string sql = this.GetSql();
            SqlParameter[] parameters = this.GetSqlParameters();
            return DBHelper.ExecuteNonQuery(conStr, sql, outObjs, parameters);
        }

        /// <summary>
        /// 获取DataSet
        /// </summary>
        /// <param name="outObjs">输出的参数集合</param>
        /// <returns>DataSet</returns>
        public virtual DataSet GetDataSet(Dictionary<string, object> outObjs = null)
        {
            string conStr = "";
            string sql = this.GetSql();
            SqlParameter[] parameters = this.GetSqlParameters();
            return DBHelper.GetDataSet(conStr, sql, outObjs, parameters);
        }


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
