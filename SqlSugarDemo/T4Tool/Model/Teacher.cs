namespace ModleT4
{
    using System;
    using SqlSugar;

    ///<summary>
    ///
    ///</summary>
    [SugarTable("Teacher")]
    public partial class Teacher
    {
           public Teacher(){

           }

           /// <summary>
           /// 
           /// </summary>           
           [SugarColumn(ColumnName="TeacherID",ColumnDescription ="")]
           public int  Teacherid {get;set;}

           /// <summary>
           /// 
           /// </summary>           
           [SugarColumn(ColumnName="TeacherName",ColumnDescription ="")]
           public string  Teachername {get;set;}

           /// <summary>
           /// 
           /// </summary>           
           [SugarColumn(ColumnName="StandardId",ColumnDescription ="")]
           public int ? Standardid {get;set;}

    }
}

