namespace My.Entity.Demo.Entity
{
    using System;
    using System.ComponentModel;   
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table("Standard")]
    public class Standard
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Column("StandardId")]
        [Display(Name = "主键", Description = "主键")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Description = "", Name = "")]
        [Column("StandardName")]
        [StringLength(50)]
        public string  StandardName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Description = "", Name = "")]
        [Column("Description")]
        [StringLength(50)]
        public string  Description { get; set; }

    }

}

