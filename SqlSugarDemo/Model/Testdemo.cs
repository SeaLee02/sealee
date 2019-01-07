using System;
using System.Linq;
using System.Text;
using SqlSugar;
using SqlSugarDemo.Db;

namespace Modle
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("TestDemo")]
    public partial class Testdemo
    {
        public Testdemo()
        {


        }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "ID")]
        public int Id { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "TestEnums")]
        public TestEnum? Testenums { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Name { get; set; }



    }
}
