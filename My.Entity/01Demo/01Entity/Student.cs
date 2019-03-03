namespace Test.T4
{
    using System;
    using System.ComponentModel;   
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table("Student")]
    public class Student
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Column("StudentID")]
        [Display(Name = "主键", Description = "主键")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Description = "", Name = "")]
        [Column("FirstName")]
        [StringLength(50)]
        public string  FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Description = "", Name = "")]
        [Column("LastName")]
        [StringLength(50)]
        public string  LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Description = "", Name = "")]
        [Column("StandardId")]
        public int?  StandardId { get; set; }

    }

}

