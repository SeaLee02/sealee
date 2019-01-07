using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Modle
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("E_tEST_sTIU")]
    public partial class ETestStiu
    {
           public ETestStiu(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="id")]
           public int? Id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="name")]
           public string Name {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="DU(12.YY)")]
           public string Du12yy {get;set;}

    }
}
