namespace Test.T4
{
    using System;
    using System.ComponentModel;   
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 测试表2
    /// </summary>
    [Table("My_Test2")]
    public class My_Test2
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Column("ID")]
        [Display(Name = "测试表2主键", Description = "测试表2主键")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Display(Description = "描述", Name = "描述")]
        [Column("Des")]
        [StringLength(50)]
        public string  Des { get; set; }

    }

}

