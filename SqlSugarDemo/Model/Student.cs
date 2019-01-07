using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Modle
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("Student")]
    public partial class Student
    {
           public Student(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true,ColumnName="StudentID")]
           public int Studentid {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="FirstName")]
           public string Firstname {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="LastName")]
           public string Lastname {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="StandardId")]
           public int? Standardid {get;set;}

    }
}
