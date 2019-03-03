namespace Test.T4
{
    using System;
    using System.ComponentModel;   
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table("TestDemo")]
    public class TestDemo
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Column("ID")]
        [Display(Name = "主键", Description = "主键")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 测试枚举(7.Sunday[星期天];1.Monday[星期一];2.Tuesday[星期二];3.Wednesday[];5.Friday)
        /// </summary>
        [Display(Description = "测试枚举(7.Sunday[星期天];1.Monday[星期一];2.Tuesday[星期二];3.Wednesday[];5.Friday)", Name = "测试枚举(7.Sunday[星期天];1.Monday[星期一];2.Tuesday[星期二];3.Wednesday[];5.Friday)")]
        [Column("TestEnums")]
        public TestEnumsEnum  TestEnums { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Description = "", Name = "")]
        [Column("SexBool")]
        public bool?  SexBool { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Description = "", Name = "")]
        [Column("HightDouble")]
        public decimal?  HightDouble { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Description = "", Name = "")]
        [Column("DateTime")]
        public DateTime?  DateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Description = "", Name = "")]
        [Column("SID")]
        public Guid?  SID { get; set; }

    }


    /// <summary>
    /// 测试枚举(7.Sunday[星期天];1.Monday[星期一];2.Tuesday[星期二];3.Wednesday[];5.Friday)
    /// </summary>
    public enum TestEnumsEnum
    {
        /// <summary>
        /// Sunday
        /// </summary>
        [Description("星期天")]
        Sunday = 7,

        /// <summary>
        /// Monday
        /// </summary>
        [Description("星期一")]
        Monday = 1,

        /// <summary>
        /// Tuesday
        /// </summary>
        [Description("星期二")]
        Tuesday = 2,

        /// <summary>
        /// Wednesday
        /// </summary>
        [Description("")]
        Wednesday = 3,

        /// <summary>
        /// Friday
        /// </summary>
        Friday = 5

    }

}

