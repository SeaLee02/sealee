namespace T4Demo.T4Tool
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("StudentAddress")]
	public class StudentAddress
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
        [Column("Address1")]
        public string Address1{ get; set; }		

         /// <summary>
        /// 
        /// </summary>
        [Display(Name ="",Description ="")]
        [Column("Address2")]
        public string Address2{ get; set; }		

         /// <summary>
        /// 
        /// </summary>
        [Display(Name ="",Description ="")]
        [Column("City")]
        public string City{ get; set; }		

         /// <summary>
        /// 
        /// </summary>
        [Display(Name ="",Description ="")]
        [Column("State")]
        public string State{ get; set; }		

    }
}
