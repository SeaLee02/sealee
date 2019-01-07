using Modle;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugarDemo.Db
{
    //可以直接用SimpleClient也可以扩展一个自个的类 
    //推荐直接用 SimpleClient 
    //为了照顾需要扩展的朋友，我们就来扩展一个SimpleClient，取名叫DbSet
    public class DbSet<T> : SimpleClient<T> where T : class, new()
    {
        public DbSet(SqlSugarClient context) : base(context)
        {

        }
        //SimpleClient中的方法满足不了你，你可以扩展自已的方法

        /// <summary>
        /// 返回可迭代的
        /// </summary>
        /// <returns></returns>
        public ISugarQueryable<T> AsQueryable()
        {
            return Context.Queryable<T>();
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public ISugarQueryable<T> Sql(string sql)
        {
            return Context.SqlQueryable<T>(sql);
        }

    }

    //创建一个DbContext类，使用DbSet(或者SimpleClient)
    public class DbContext
    {
        public DbContext()
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = @"server=PV-X00273458\SQLEXPRESS;uid=sa;pwd=123;database=SchoolDB",
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });

            ////调式代码 用来打印SQL 
            //Db.Aop.OnLogExecuting = (sql, pars) =>
            //{
            //    Console.WriteLine(sql + "\r\n" +
            //        Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
            //    Console.WriteLine();
            //};
        }
        public SqlSugarClient Db;//用来处理事务多表查询和复杂的操作

        public DbSet<Standard> Standards { get { return new DbSet<Standard>(Db); } }
        public DbSet<Testdemo> Testdemos { get { return new DbSet<Testdemo>(Db); } }

        

    }

}
