namespace ModleT4
{
    using System;
    using SqlSugar;

    ///<summary>
    ///课程表
    ///</summary>
    [SugarTable("Course")]
    public partial class Course
    {
           public Course(){

           }

           /// <summary>
           /// 课程ID
           /// </summary>           
           [SugarColumn(ColumnName="CourseId",ColumnDescription ="课程ID")]
           public int  Courseid {get;set;}

           /// <summary>
           /// 课程名称
           /// </summary>           
           [SugarColumn(ColumnName="CourseName",ColumnDescription ="课程名称")]
           public string  Coursename {get;set;}

           /// <summary>
           /// 地址
           /// </summary>           
           [SugarColumn(ColumnName="Location",ColumnDescription ="地址")]
           public string  Location {get;set;}

           /// <summary>
           /// 教师ID
           /// </summary>           
           [SugarColumn(ColumnName="TeacherId",ColumnDescription ="教师ID")]
           public int ? Teacherid {get;set;}

    }
}

