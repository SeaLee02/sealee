namespace Sealee.Util
{
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    public class HttpHelper
    {

       /// <summary>
       /// get请求  await GetHttp()异步，  GetHttp().
       /// </summary>
       /// <param name="url">请求的url</param>
       /// <returns></returns>
        public static async Task<string> GetHttp(string url)
        {
            var client = new HttpClient();
            var result = client.GetAsync(url);
            //if (!result.IsSuccessStatusCode) return null;
            return await result.Result.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// 返回字节
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<byte[]> GetHttpToByte(string url)
        {
            var client = new HttpClient();
            var result = client.GetAsync(url);
            return await result.Result.Content.ReadAsByteArrayAsync();
        }

        //post请求
        public static async Task<string> PostHttp(string url, string content)
        {
            var client = new HttpClient();
            var result = client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));
            //post传过去的字符串最好编码
            //if (!result.IsSuccessStatusCode) return null;
            return await result.Result.Content.ReadAsStringAsync();
        }
    }
}
