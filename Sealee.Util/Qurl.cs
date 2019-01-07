namespace Sealee.Util
{
    using System.Reflection;
    /// <summary>
    /// 根据输入类拼接参数
    /// </summary>
    public class Qurl
    {
        public static string GetUrlQ<T>(T t)
        {
            string urlQ = "?";
            foreach (PropertyInfo item in t.GetType().GetProperties())
            {
                urlQ += $"{item.Name}={item.GetValue(t, null)}&";
            }
            return urlQ.TrimEnd('&');
        }
    }
}

