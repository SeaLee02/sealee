namespace T4Demo.T4Tool
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("My_Test2")]
	public class My_Test2
	{
         /// <summary>
        /// 主键
        /// </summary>
        [Display(Name ="主键",Description ="主键")]
        [Column("ID")]
        public int ID{ get; set; }		

         /// <summary>
        /// 描述
        /// </summary>
        [Display(Name ="描述",Description ="描述")]
        [Column("Des")]
        public string Des{ get; set; }		

    }
}
