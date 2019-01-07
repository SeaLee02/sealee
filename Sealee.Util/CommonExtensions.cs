using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.International.Converters.PinYinConverter;  //nuget

namespace Sealee.Util
{
    public static class CommonExtensions
    {

        #region String扩展方法
        /// <summary> 
        /// 汉字转化为拼音  
        /// </summary> 
        /// <param name="str">汉字</param> 
        /// <returns>全拼</returns> 
        public static string GetPinyin(this string str)
        {
            string r = string.Empty;
            foreach (char obj in str)
            {
                try
                {
                    ChineseChar chineseChar = new ChineseChar(obj);
                    string t = chineseChar.Pinyins[0].ToString();
                    r += t.Substring(0, t.Length - 1);
                }
                catch
                {
                    r += obj.ToString();
                }
            }
            return r;
        }
        /// <summary> 
        /// 汉字转化为拼音首字母 
        /// </summary> 
        /// <param name="str">汉字</param> 
        /// <returns>首字母</returns> 
        public static string GetFirstPinyin(this string str)
        {
            string r = string.Empty;
            foreach (char obj in str)
            {
                try
                {
                    ChineseChar chineseChar = new ChineseChar(obj);
                    string t = chineseChar.Pinyins[0].ToString();
                    r += t.Substring(0, 1);
                }
                catch
                {
                    r += obj.ToString();
                }
            }
            return r;
        }

        /// <summary>
        ///     String 转换 Int
        /// </summary>
        /// <returns></returns>
        public static int ToInt(this string str, int defaultValue = int.MinValue)
        {
            int result;
            if (!int.TryParse(str, out result))
            {
                if (defaultValue != int.MinValue)
                    result = defaultValue;
                else
                    throw new Exception(str + "无法转换成整数类型！");
            }
            return result;
        }

        /// <summary>
        /// String 转换 Decimal
        /// </summary>
        /// <returns></returns>
        public static decimal ToDecimal(this string str, decimal defaultValue = decimal.MinValue)
        {
            decimal result;
            if (!decimal.TryParse(str, out result))
            {
                if (defaultValue != decimal.MinValue)
                    result = defaultValue;
                else
                    throw new Exception(str + "无法转换成数值类型！");
            }
            return result;
        }

        /// <summary>
        ///     String 转换 Float
        /// </summary>
        /// <returns></returns>
        public static float ToFloat(this string str, float defaultValue = float.MinValue)
        {
            float result;
            if (!float.TryParse(str, out result))
            {
                if (defaultValue != float.MinValue)
                    result = defaultValue;
                else
                    throw new Exception(str + "无法转换成数值类型！");
            }
            return result;
        }

        /// <summary>
        ///     String 转换 Double
        /// </summary>
        /// <returns></returns>
        public static double ToDouble(this string str, double defaultValue = double.MinValue)
        {
            double result;
            if (!double.TryParse(str, out result))
            {
                if (defaultValue != double.MinValue)
                    result = defaultValue;
                else
                    throw new Exception(str + "无法转换成数值类型！");
            }
            return result;
        }

        /// <summary>
        /// String 转换 DateTime
        /// </summary>
        /// <returns></returns>
        public static DateTime ToDateTime(this string str, string defaultValue = "")
        {
            DateTime result;
            if (!DateTime.TryParse(str, out result))
            {
                if (defaultValue != "")
                    DateTime.TryParse(defaultValue, out result);
                else
                    throw new Exception(str + "不是有效的时间格式");
            }
            return result;
        }
        #endregion\

        #region  枚举的扩展方法
        /// <summary>
        /// 根据枚举值获取枚举描述
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <returns>描述字符串</returns>
        public static string EnumGetDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            if (fi != null)
            {
                var attributes =
                    (DescriptionAttribute[])fi.GetCustomAttributes(
                        typeof(DescriptionAttribute), false); //获取描述的集合
                return attributes.Length > 0 ? attributes[0].Description : value.ToString(); //存在取第一个,不存在返回Name
            }
            return "";
        }

        /// <summary>
        /// 获取根据枚举名称获取枚举描述
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="enumName">枚举名称</param>
        /// <returns></returns>
        public static string EnumGetDescription<T>(this string enumName)
        {
            var fi = typeof(T).GetField(enumName);
            if (fi != null)
            {
                var attributes =
                    (DescriptionAttribute[])fi.GetCustomAttributes(
                        typeof(DescriptionAttribute), false);
                return attributes.Length > 0 ? attributes[0].Description : enumName;
            }
            return "";
        }
        #endregion

        /// <summary>
        /// 合并数组    把单个的集合变成多个的集合  [1,2,3,4,5]  =>  [[1,2],[3,4],[5]] 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="chunkSize"></param>
        /// <returns></returns>
        public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }

        /// <summary>
        /// 字符串处理  (_切分，首字母大写 （.)去除  )
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToCase(this string value)
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
                str += firstLetter.ToUpper() + rest.ToLower();
            }
            return str;
        }
    }
}
