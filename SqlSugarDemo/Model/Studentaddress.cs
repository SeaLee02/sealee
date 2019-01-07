using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Modle
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("StudentAddress")]
    public partial class Studentaddress
    {
           public Studentaddress(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="StudentID")]
           public int? Studentid {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Address1 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Address2 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string City {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string State {get;set;}

    }
}
