namespace Test.T4
{
    using System;
    using System.ComponentModel;   
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 测试表1
    /// </summary>
    [Table("My_Test1")]
    public class My_Test1
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Column("Id")]
        [Display(Name = "测试表1主键", Description = "测试表1主键")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Description = "姓名", Name = "姓名")]
        [Column("Name")]
        [StringLength(50)]
        public string  Name { get; set; }

    }

}

