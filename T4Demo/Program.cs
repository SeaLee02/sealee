using Sealee.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 获取表和列
            string tables = "";
            string connectionStrng = @"server=PV-X00273458\SQLEXPRESS;uid=sa;pwd=123;database=SchoolDB";
            List<DbTable> tablesList = DbHelper.GetDbTables(connectionStrng, "SchoolDB", tables);
            foreach (DbTable item in tablesList)
            {
                List<DbColumn> columnList = DbHelper.GetDbColumns(connectionStrng, "SchoolDB", item.TableName);
            }
            #endregion
        }
    }
}
