namespace My.Entity.Demo.Entity
{
    using System;
    using System.ComponentModel;   
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 课程表
    /// </summary>
    [Table("Course")]
    public class Course
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Column("CourseId")]
        [Display(Name = "课程表主键", Description = "课程表主键")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 课程名称
        /// </summary>
        [Display(Description = "课程名称", Name = "课程名称")]
        [Column("CourseName")]
        [StringLength(50)]
        public string  CourseName { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Display(Description = "地址", Name = "地址")]
        [Column("Location")]
        [StringLength(50)]
        public string  Location { get; set; }

        /// <summary>
        /// 教师ID
        /// </summary>
        [Display(Description = "教师ID", Name = "教师ID")]
        [Column("TeacherId")]
        public int?  TeacherId { get; set; }

    }

}

