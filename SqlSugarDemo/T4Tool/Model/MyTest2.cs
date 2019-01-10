namespace ModleT4
{
    using System;
    using SqlSugar;

    ///<summary>
    ///测试表2
    ///</summary>
    [SugarTable("My_Test2")]
    public partial class MyTest2
    {
           public MyTest2(){

           }

           /// <summary>
           /// 主键
           /// </summary>           
           [SugarColumn(ColumnName="ID",ColumnDescription ="主键")]
           public int  Id {get;set;}

           /// <summary>
           /// 描述
           /// </summary>           
           [SugarColumn(ColumnName="Des",ColumnDescription ="描述")]
           public string  Des {get;set;}

    }
}

