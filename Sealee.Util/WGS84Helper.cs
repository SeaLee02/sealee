using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sealee.Util
{
    /// <summary>
    /// 百度转wgs84坐标系
    /// </summary>
    public class WGS84Helper
    {
        private readonly static double x_PI = 3.14159265358979324 * 3000.0 / 180.0;
        private readonly static double PI = 3.1415926535897932384626;
        private readonly static double a = 6378245.0;
        private readonly static double ee = 0.00669342162296594323;

        /// <summary>
        /// 百度坐标系 (BD-09) 与 火星坐标系 (GCJ-02)的转换   百度 转 谷歌、高德
        /// </summary>
        /// <param name="bd_lon"></param>
        /// <param name="bd_lat"></param>
        /// <returns></returns>
        public static double[] bd09togcj02(double bd_lon, double bd_lat)
        {
            double x = bd_lon - 0.0065;
            double y = bd_lat - 0.006;
            double z = Math.Sqrt(x * x + y * y) - 0.00002 * Math.Sin(y * x_PI);
            double theta = Math.Atan2(y, x) - 0.000003 * Math.Cos(x * x_PI);
            double gg_lng = z * Math.Cos(theta);
            double gg_lat = z * Math.Sin(theta);
            return new double[] { gg_lng, gg_lat };
        }

        /// <summary>
        /// GCJ02 转换为 WGS84
        /// </summary>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        /// <returns></returns>
        public static double[] gcj02towgs84(double lng, double lat)
        {
            if (out_of_china(lng, lat))
            {
                return new double[] { lng, lat };
            }
            else
            {
                double dlat = transformlat(lng - 105.0, lat - 35.0);
                double dlng = transformlng(lng - 105.0, lat - 35.0);
                double radlat = lat / 180.0 * PI;
                double magic = Math.Sin(radlat);
                magic = 1 - ee * magic * magic;
                double sqrtmagic = Math.Sqrt(magic);
                dlat = (dlat * 180.0) / ((a * (1 - ee)) / (magic * sqrtmagic) * PI);
                dlng = (dlng * 180.0) / (a / sqrtmagic * Math.Cos(radlat) * PI);
                double mglat = lat + dlat;
                double mglng = lng + dlng;
                return new double[] { lng * 2 - mglng, lat * 2 - mglat };
            }
        }

        private static double transformlat(double lng, double lat)
        {
            double ret = -100.0 + 2.0 * lng + 3.0 * lat + 0.2 * lat * lat + 0.1 * lng * lat + 0.2 * Math.Sqrt(Math.Abs(lng));
            ret += (20.0 * Math.Sin(6.0 * lng * PI) + 20.0 * Math.Sin(2.0 * lng * PI)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(lat * PI) + 40.0 * Math.Sin(lat / 3.0 * PI)) * 2.0 / 3.0;
            ret += (160.0 * Math.Sin(lat / 12.0 * PI) + 320 * Math.Sin(lat * PI / 30.0)) * 2.0 / 3.0;
            return ret;
        }


        private static double transformlng(double lng, double lat)
        {
            double ret = 300.0 + lng + 2.0 * lat + 0.1 * lng * lng + 0.1 * lng * lat + 0.1 * Math.Sqrt(Math.Abs(lng));
            ret += (20.0 * Math.Sin(6.0 * lng * PI) + 20.0 * Math.Sin(2.0 * lng * PI)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(lng * PI) + 40.0 * Math.Sin(lng / 3.0 * PI)) * 2.0 / 3.0;
            ret += (150.0 * Math.Sin(lng / 12.0 * PI) + 300.0 * Math.Sin(lng / 30.0 * PI)) * 2.0 / 3.0;
            return ret;
        }

        /// <summary>
        ///     判断是否在国内，不在国内则不做偏移
        /// </summary>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        /// <returns></returns>
        private static bool out_of_china(double lng, double lat)
        {
            // 纬度3.86~53.55,经度73.66~135.05 
            return !(lng > 73.66 && lng < 135.05 && lat > 3.86 && lat < 53.55);
        }

    }
}
