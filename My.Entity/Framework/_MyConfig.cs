using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sealee.T4Helper;

namespace My.Entity.Framework
{
    public class _MyConfig
    {
        private MyConfig _config;
        public _MyConfig()
        {
            _config = StringUtil.GetConfig(AppDomain.CurrentDomain.BaseDirectory + "_file\\T4Helper.json");
        }
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString => _config.ConnectionString;

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
