namespace Test.T4
{
    using System;   
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table("View_Course")]
    public class View_Course
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Description = "", Name = "")]
        [Column("CourseId")]
        public int  CourseId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Description = "", Name = "")]
        [Column("CourseName")]
        [StringLength(50)]
        public string  CourseName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Description = "", Name = "")]
        [Column("Location")]
        [StringLength(50)]
        public string  Location { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Description = "", Name = "")]
        [Column("TeacherId")]
        public int?  TeacherId { get; set; }

    }
}

