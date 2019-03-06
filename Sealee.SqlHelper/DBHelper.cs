using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sealee.SqlHelper
{
    public class DBHelper
    {
        /// <summary>
        /// 返回受影响的行
        /// </summary>
        /// <param name="conStr"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string conStr, string sql, Dictionary<string, object> keys = null,params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = sql;
                command.Parameters.AddRange(parameters.ToArray());
                foreach (SqlParameter item in parameters)
                {
                    if (item.Direction == ParameterDirection.Output)
                    {
                        keys[item.ParameterName] = command.Parameters[item.ParameterName].Value;
                    }
                }
                return command.ExecuteNonQuery();
            }

        }

        /// <summary>
        /// 一行数据
        /// </summary>
        /// <typeparam name="T">需要转换的类</typeparam>
        /// <param name="conStr">连接字符串</param>
        /// <param name="sql">查询的sql</param>
        /// <param name="parameters">参数集合</param>
        /// <param name="keys">输出参数</param>
        /// <returns></returns>
        public static T ExecuteScalar<T>(string conStr, string sql, Dictionary<string, object> keys = null, params SqlParameter[] parameters)
        {
            List<T> result = new List<T>();
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = sql;
                command.Parameters.AddRange(parameters.ToArray());
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);//执行的结构填充到我们的表格中
                foreach (SqlParameter item in parameters)
                {
                    if (item.Direction == ParameterDirection.Output)
                    {
                        keys[item.ParameterName] = command.Parameters[item.ParameterName].Value;
                    }
                }
                foreach (DataRow item in dt.Rows)
                {
                    T d = Activator.CreateInstance<T>();
                    Type pp = typeof(T);
                    PropertyInfo[] ppList = pp.GetProperties();
                    foreach (PropertyInfo pro in pp.GetProperties())
                    {
                        Type s = pro.PropertyType;
                        pro.SetValue(d, item[pro.Name], null);//进行数据映射
                    }
                    result.Add(d);
                }
            }
            return result[0];
        }

        /// <summary>
        ///  获取集合
        /// </summary>
        /// <typeparam name="T">需要转换的类</typeparam>
        /// <param name="conStr">连接字符串</param>
        /// <param name="sql">查询的sql</param>
        /// <param name="parameters">参数集合</param>
        /// <param name="keys">输出参数</param>
        /// <returns></returns>
        public static List<T> QueryList<T>(string conStr, string sql, Dictionary<string, object> keys = null, params SqlParameter[] parameters)
        {
            List<T> result = new List<T>();
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = sql;
                command.Parameters.AddRange(parameters.ToArray());
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);//执行的结构填充到我们的表格中
                foreach (SqlParameter item in parameters)
                {
                    if (item.Direction == ParameterDirection.Output)
                    {
                        keys[item.ParameterName] = command.Parameters[item.ParameterName].Value;
                    }
                }
                foreach (DataRow item in dt.Rows)
                {
                    T d = Activator.CreateInstance<T>();
                    Type pp = typeof(T);
                    PropertyInfo[] ppList = pp.GetProperties();
                    foreach (PropertyInfo pro in pp.GetProperties())
                    {
                        Type s = pro.PropertyType;
                        pro.SetValue(d, item[pro.Name], null);//进行数据映射
                    }
                    result.Add(d);
                }
            }
            return result;
        }

        /// <summary>
        /// 执行Sql语句获取DataTable
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="commandText"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string connectionString, string commandText, Dictionary<string, object> keys = null, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = commandText;
                command.Parameters.AddRange(parameters);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet set = new DataSet();
                adapter.Fill(set);
                foreach (SqlParameter item in parameters)
                {
                    if (item.Direction == ParameterDirection.Output)
                    {
                        keys[item.ParameterName] = command.Parameters[item.ParameterName].Value;
                    }
                }
                return set;
            }
        }
    }
}

/* 使用案列
 string sqlcon = @"server=DESKTOP-UTQ1325\SQLSERVER2012;uid=sa;password=123;database=Test";
List<SqlParameter> parameters = new List<SqlParameter>();
string sql = "EXEC dbo.TestPro3 @id,@Outtitle OUTPUT";
parameters.Add(new SqlParameter("@id", 1));
            SqlParameter outPar = new SqlParameter("@Outtitle", SqlDbType.NVarChar, 100);
outPar.Direction = ParameterDirection.Output;  //标识为输出参数
            parameters.Add(outPar);
            Dictionary<string, object> keys = new Dictionary<string, object>();  //用来存储输出参数
List<TestMapp> test = new Program().QueryList<TestMapp>(sqlcon, sql, parameters.ToArray(), keys);
string returnString = keys["@Outtitle"].ToString();
 */

