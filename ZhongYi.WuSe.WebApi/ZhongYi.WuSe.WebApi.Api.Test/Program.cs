using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ZhongYi.WuSe.WebApi.Api.Test
{
    using System.Net.Http;

    class Program
    {
        static void Main(string[] args)
        {
            var querys = BuildQuerys(null);

            HttpClient client = new HttpClient();
            var content = new FormUrlEncodedContent(new Dictionary<string, string>());
            var task = client.PostAsync("http://localhost:52066/api/v1/shop/info", content);
            task.Wait();
            var result = task.Result;
            Console.WriteLine(result.Content.ReadAsStringAsync().Result);
            Console.ReadKey();


        }

        /// <summary>
        /// 构建参数
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        private static string BuildQuerys(Dictionary<string, object> dict)
        {
            Dictionary<string, object> commonQuerys = new Dictionary<string, object>();
            commonQuerys.Add("Platform", "iphone");
            commonQuerys.Add("Ip", "10.10.11.132");
            commonQuerys.Add("OS", "IOS");
            commonQuerys.Add("OSVersion", "IOS8.0.2");
            commonQuerys.Add("ScreenHeight", 100);
            commonQuerys.Add("ScreenWidth", 200);
            commonQuerys.Add("SessionId", "d7144c7e-a5ba-4e37-a671-d5e5e2ffcc72");
            commonQuerys.Add("SourcesId", "100001");
            commonQuerys.Add("MacId", "01:01:01:01");
            commonQuerys.Add("IMEI", "134567812768");
            commonQuerys.Add("DeviceName", "iphone4s");
            commonQuerys.Add("CustomerId", "13");
            commonQuerys.Add("ClientVersion", "快店1.1");
            commonQuerys.Add("ChannelId", "3010900");
            commonQuerys.Add("Carrier", "中国移动");
            commonQuerys.Add("ApiVersion", "1.0");
            commonQuerys.Add("TimeReq", "130582620123262762");

            commonQuerys.Add("sign", "5f1261c39b506bbfce7f7757ae5035a51");

            if (dict != null)
            {
                foreach (var value in dict)
                {
                    commonQuerys.Add(value.Key, value.Value);
                }
            }

            StringBuilder querys = new StringBuilder();
            foreach (var query in commonQuerys)
            {
                querys.AppendFormat("{0}={1}&", query.Key, query.Value);
            }

            return querys.ToString().TrimEnd('&');
        }
    }
}
