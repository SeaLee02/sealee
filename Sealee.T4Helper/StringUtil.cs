using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Sealee.T4Helper
{
    public class StringUtil
    {
        /// <summary>
        /// 首字母小写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetUpperF(string str)
        {
            return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(str);
        }

        /// <summary>
        /// 序列化json文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static MyConfig GetConfig(string filePath = null)
        {
            if (File.Exists(filePath))
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                return javaScriptSerializer.Deserialize<MyConfig>(File.ReadAllText(filePath));
            }
            return null;
        }

        /// <summary>
        /// 转小写
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToCase(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            string[] arry = value.Split('_');
            string str = "";
            foreach (string item in arry)
            {
                string newstr = item.Replace("(", "").Replace(".", "").Replace(")", "");
                string firstLetter = newstr.Substring(0, 1);
                string rest = newstr.Substring(1, newstr.Length - 1);
                str += firstLetter.ToUpper() + rest;
            }
            return str;
        }
    }
}
