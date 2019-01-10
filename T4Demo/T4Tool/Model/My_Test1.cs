namespace T4Demo.T4Tool
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("My_Test1")]
	public class My_Test1
	{
         /// <summary>
        /// 主键
        /// </summary>
        [Display(Name ="主键",Description ="主键")]
        [Column("Id")]
        public int Id{ get; set; }		

         /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name ="姓名",Description ="姓名")]
        [Column("Name")]
        public string Name{ get; set; }		

    }
}
