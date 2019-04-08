using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sealee.T4Helper
{
    public class MyConfig
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 命名空间
        /// </summary>
        public string NameSpace { get; set; }          

        /// <summary>
        /// 是否覆盖文件
        /// </summary>
        public bool IsOverrideFile { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        public string Version { get; set; }     
    }
}
