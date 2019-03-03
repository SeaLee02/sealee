namespace Sealee.T4Helper
{
    using System;

    /// <summary>
    /// 参数列的信息
    /// </summary>
    public class DbObjColumn
    {
        /// <summary>
        /// 列名称
        /// </summary>
        public string ObjColumnName { get; set; }

        /// <summary>
        /// 列类型
        /// </summary>
        public string ObjColumnType { get; set; }

        /// <summary>
        /// c#类型
        /// </summary>
        public string CShareType => SqlServerDbTypeMap.MapCsharpType(ObjColumnType);

        /// <summary>
        /// 基类
        /// </summary>              
        public Type CommonType => SqlServerDbTypeMap.MapCommonType(ObjColumnType);

        /// <summary>
        /// 字节长度
        /// </summary>                      
        public int ByteLength { get; set; }

        /// <summary>
        /// 字符长度
        /// </summary>
        public int CharLength { get; set; }

        /// <summary>
        /// 列描述
        /// </summary>
        public string ObjColumnDesc { get; set; }

        public int Precision { get; set; }

        public int Scale { get; set; }

        /// <summary>
        /// 表明
        /// </summary>
        public string ObjName { get; set; }

        /// <summary>
        /// 是否为输出参数
        /// </summary>
        public bool IsOutPut { get; set; }
    }
}
