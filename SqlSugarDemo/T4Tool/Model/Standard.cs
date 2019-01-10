namespace ModleT4
{
    using System;
    using SqlSugar;

    ///<summary>
    ///
    ///</summary>
    [SugarTable("Standard")]
    public partial class Standard
    {
           public Standard(){

           }

           /// <summary>
           /// 
           /// </summary>           
           [SugarColumn(ColumnName="StandardId",ColumnDescription ="")]
           public int  Standardid {get;set;}

           /// <summary>
           /// 
           /// </summary>           
           [SugarColumn(ColumnName="StandardName",ColumnDescription ="")]
           public string  Standardname {get;set;}

           /// <summary>
           /// 
           /// </summary>           
           [SugarColumn(ColumnName="Description",ColumnDescription ="")]
           public string  Description {get;set;}

    }
}

