namespace ModleT4
{
    using System;
    using SqlSugar;

    ///<summary>
    ///
    ///</summary>
    [SugarTable("StudentAddress")]
    public partial class Studentaddress
    {
           public Studentaddress(){

           }

           /// <summary>
           /// 
           /// </summary>           
           [SugarColumn(ColumnName="StudentID",ColumnDescription ="")]
           public int ? Studentid {get;set;}

           /// <summary>
           /// 
           /// </summary>           
           [SugarColumn(ColumnName="Address1",ColumnDescription ="")]
           public string  Address1 {get;set;}

           /// <summary>
           /// 
           /// </summary>           
           [SugarColumn(ColumnName="Address2",ColumnDescription ="")]
           public string  Address2 {get;set;}

           /// <summary>
           /// 
           /// </summary>           
           [SugarColumn(ColumnName="City",ColumnDescription ="")]
           public string  City {get;set;}

           /// <summary>
           /// 
           /// </summary>           
           [SugarColumn(ColumnName="State",ColumnDescription ="")]
           public string  State {get;set;}

    }
}

