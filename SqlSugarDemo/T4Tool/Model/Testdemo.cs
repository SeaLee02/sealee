namespace ModleT4
{
    using System;
    using SqlSugar;

    ///<summary>
    ///
    ///</summary>
    [SugarTable("TestDemo")]
    public partial class Testdemo
    {
           public Testdemo(){

           }

           /// <summary>
           /// 
           /// </summary>           
           [SugarColumn(ColumnName="ID",ColumnDescription ="")]
           public int  Id {get;set;}

           /// <summary>
           /// 
           /// </summary>           
           [SugarColumn(ColumnName="TestEnums",ColumnDescription ="")]
           public int ? Testenums {get;set;}

           /// <summary>
           /// 
           /// </summary>           
           [SugarColumn(ColumnName="SexBool",ColumnDescription ="")]
           public bool ? Sexbool {get;set;}

           /// <summary>
           /// 
           /// </summary>           
           [SugarColumn(ColumnName="HightDouble",ColumnDescription ="")]
           public decimal ? Hightdouble {get;set;}

           /// <summary>
           /// 
           /// </summary>           
           [SugarColumn(ColumnName="DateTime",ColumnDescription ="")]
           public DateTime ? Datetime {get;set;}

           /// <summary>
           /// 
           /// </summary>           
           [SugarColumn(ColumnName="SID",ColumnDescription ="")]
           public Guid ? Sid {get;set;}

    }
}

