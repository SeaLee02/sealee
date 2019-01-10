namespace T4Demo.T4Tool
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("Course")]
	public class Course
	{
         /// <summary>
        /// 课程ID
        /// </summary>
        [Display(Name ="课程ID",Description ="课程ID")]
        [Column("CourseId")]
        public int CourseId{ get; set; }		

         /// <summary>
        /// 课程名称
        /// </summary>
        [Display(Name ="课程名称",Description ="课程名称")]
        [Column("CourseName")]
        public string CourseName{ get; set; }		

         /// <summary>
        /// 地址
        /// </summary>
        [Display(Name ="地址",Description ="地址")]
        [Column("Location")]
        public string Location{ get; set; }		

         /// <summary>
        /// 教师ID
        /// </summary>
        [Display(Name ="教师ID",Description ="教师ID")]
        [Column("TeacherId")]
        public int TeacherId{ get; set; }		

    }
}
