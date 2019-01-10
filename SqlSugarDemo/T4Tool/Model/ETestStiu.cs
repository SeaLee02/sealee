namespace ModleT4
{
    using System;
    using SqlSugar;

    ///<summary>
    ///
    ///</summary>
    [SugarTable("E_tEST_sTIU")]
    public partial class ETestStiu
    {
           public ETestStiu(){

           }

           /// <summary>
           /// 
           /// </summary>           
           [SugarColumn(ColumnName="id",ColumnDescription ="")]
           public int ? Id {get;set;}

           /// <summary>
           /// 
           /// </summary>           
           [SugarColumn(ColumnName="name",ColumnDescription ="")]
           public string  Name {get;set;}

           /// <summary>
           /// 
           /// </summary>           
           [SugarColumn(ColumnName="DU(12.YY)",ColumnDescription ="")]
           public string  Du12yy {get;set;}

    }
}

