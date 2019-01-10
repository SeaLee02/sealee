namespace T4Demo.T4Tool
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("Teacher")]
	public class Teacher
	{
         /// <summary>
        /// 
        /// </summary>
        [Display(Name ="",Description ="")]
        [Column("TeacherID")]
        public int TeacherID{ get; set; }		

         /// <summary>
        /// 
        /// </summary>
        [Display(Name ="",Description ="")]
        [Column("TeacherName")]
        public string TeacherName{ get; set; }		

         /// <summary>
        /// 
        /// </summary>
        [Display(Name ="",Description ="")]
        [Column("StandardId")]
        public int StandardId{ get; set; }		

    }
}
