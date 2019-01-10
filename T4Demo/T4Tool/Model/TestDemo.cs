namespace T4Demo.T4Tool
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("TestDemo")]
	public class TestDemo
	{
         /// <summary>
        /// 
        /// </summary>
        [Display(Name ="",Description ="")]
        [Column("ID")]
        public int ID{ get; set; }		

         /// <summary>
        /// 
        /// </summary>
        [Display(Name ="",Description ="")]
        [Column("TestEnums")]
        public int TestEnums{ get; set; }		

         /// <summary>
        /// 
        /// </summary>
        [Display(Name ="",Description ="")]
        [Column("SexBool")]
        public bool SexBool{ get; set; }		

         /// <summary>
        /// 
        /// </summary>
        [Display(Name ="",Description ="")]
        [Column("HightDouble")]
        public decimal HightDouble{ get; set; }		

         /// <summary>
        /// 
        /// </summary>
        [Display(Name ="",Description ="")]
        [Column("DateTime")]
        public DateTime DateTime{ get; set; }		

         /// <summary>
        /// 
        /// </summary>
        [Display(Name ="",Description ="")]
        [Column("SID")]
        public Guid SID{ get; set; }		

    }
}
