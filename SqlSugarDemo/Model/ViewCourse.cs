using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Modle
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("View_Course")]
    public partial class ViewCourse
    {
           public ViewCourse(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsIdentity=true,ColumnName="CourseId")]
           public int Courseid {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="CourseName")]
           public string Coursename {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Location {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="TeacherId")]
           public int? Teacherid {get;set;}

    }
}
