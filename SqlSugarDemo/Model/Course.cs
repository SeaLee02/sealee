using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Modle
{
    ///<summary>
    ///课程表
    ///</summary>
    [SugarTable("Course")]
    public partial class Course
    {
           public Course(){


           }
           /// <summary>
           /// Desc:课程ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true,ColumnName="CourseId")]
           public int Courseid {get;set;}

           /// <summary>
           /// Desc:课程名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="CourseName")]
           public string Coursename {get;set;}

           /// <summary>
           /// Desc:地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Location {get;set;}

           /// <summary>
           /// Desc:教师ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="TeacherId")]
           public int? Teacherid {get;set;}

    }
}
