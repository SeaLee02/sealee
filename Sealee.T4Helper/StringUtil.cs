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
        public static string GetUpperF(string str)
        {
            return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(str);
        }

        public static MyConfig GetConfig(string filePath=null)
        {
            if (File.Exists(filePath))
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                return javaScriptSerializer.Deserialize<MyConfig>(File.ReadAllText(filePath));
            }
            return null;
        }
    }
}
