namespace Sealee.T4Helper
{
    using System;
    using System.Collections.Generic;

    public class DbView
    {                
        /// <summary>
        /// 视图名称
        /// </summary>
        public string ViewName { get; set; }

        /// <summary>
        /// 视图描述
        /// </summary>
        public string ViewDesc { get; set; }

        /// <summary>
        /// 列信息
        /// </summary>
        public List<DbColumn> DbColumns { get; set; }
    }
}
