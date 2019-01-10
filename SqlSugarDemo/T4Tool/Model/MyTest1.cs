namespace ModleT4
{
    using System;
    using SqlSugar;

    ///<summary>
    ///测试表1
    ///</summary>
    [SugarTable("My_Test1")]
    public partial class MyTest1
    {
           public MyTest1(){

           }

           /// <summary>
           /// 主键
           /// </summary>           
           [SugarColumn(ColumnName="Id",ColumnDescription ="主键")]
           public int  Id {get;set;}

           /// <summary>
           /// 姓名
           /// </summary>           
           [SugarColumn(ColumnName="Name",ColumnDescription ="姓名")]
           public string  Name {get;set;}

    }
}

