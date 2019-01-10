namespace ModleT4
{
    using System;
    using SqlSugar;

    ///<summary>
    ///
    ///</summary>
    [SugarTable("Student")]
    public partial class Student
    {
           public Student(){

           }

           /// <summary>
           /// 
           /// </summary>           
           [SugarColumn(ColumnName="StudentID",ColumnDescription ="")]
           public int  Studentid {get;set;}

           /// <summary>
           /// 
           /// </summary>           
           [SugarColumn(ColumnName="FirstName",ColumnDescription ="")]
           public string  Firstname {get;set;}

           /// <summary>
           /// 
           /// </summary>           
           [SugarColumn(ColumnName="LastName",ColumnDescription ="")]
           public string  Lastname {get;set;}

           /// <summary>
           /// 
           /// </summary>           
           [SugarColumn(ColumnName="StandardId",ColumnDescription ="")]
           public int ? Standardid {get;set;}

    }
}

