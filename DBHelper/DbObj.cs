namespace Sealee.T4Helper
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 存储过程,视图等等
    /// </summary>
    public class DbObj
    {
        /// <summary>
        /// 对象名
        /// </summary>
        public string ObjName { get; set; }

        /// <summary>
        /// 对象描述
        /// </summary>
        public string ObjDesc { get; set; }

        /// <summary>
        /// 列信息
        /// </summary>
        public List<DbObjColumn> DbObjColumns { get; set; }
    }
}
