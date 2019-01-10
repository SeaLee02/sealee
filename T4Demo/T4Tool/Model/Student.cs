namespace T4Demo.T4Tool
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("Student")]
	public class Student
	{
         /// <summary>
        /// 
        /// </summary>
        [Display(Name ="",Description ="")]
        [Column("StudentID")]
        public int StudentID{ get; set; }		

         /// <summary>
        /// 
        /// </summary>
        [Display(Name ="",Description ="")]
        [Column("FirstName")]
        public string FirstName{ get; set; }		

         /// <summary>
        /// 
        /// </summary>
        [Display(Name ="",Description ="")]
        [Column("LastName")]
        public string LastName{ get; set; }		

         /// <summary>
        /// 
        /// </summary>
        [Display(Name ="",Description ="")]
        [Column("StandardId")]
        public int StandardId{ get; set; }		

    }
}
