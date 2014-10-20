namespace ZhongYi.WuSe.WebApi.Logic.Helpers
{
    using System.Web;

    public class CommonHelper
    {
        /// <summary>
        /// 获取客户端Ip地址
        /// </summary>
        /// <returns></returns>
        public static string GetIPAddress()
        {
            string IpAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(IpAddress))
            {
                IpAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (!string.IsNullOrEmpty(IpAddress))
                IpAddress = IpAddress.Split(',')[0];

            return IpAddress;
        }
    }
}
