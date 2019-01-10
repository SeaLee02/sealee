namespace T4Demo.T4Tool
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("Standard")]
	public class Standard
	{
         /// <summary>
        /// 
        /// </summary>
        [Display(Name ="",Description ="")]
        [Column("StandardId")]
        public int StandardId{ get; set; }		

         /// <summary>
        /// 
        /// </summary>
        [Display(Name ="",Description ="")]
        [Column("StandardName")]
        public string StandardName{ get; set; }		

         /// <summary>
        /// 
        /// </summary>
        [Display(Name ="",Description ="")]
        [Column("Description")]
        public string Description{ get; set; }		

    }
}
