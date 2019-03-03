namespace Test.T4
{
    using System;
    using System.ComponentModel;   
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table("Teacher")]
    public class Teacher
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Column("TeacherID")]
        [Display(Name = "主键", Description = "主键")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Description = "", Name = "")]
        [Column("TeacherName")]
        [StringLength(50)]
        public string  TeacherName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Description = "", Name = "")]
        [Column("StandardId")]
        public int?  StandardId { get; set; }

    }

}

