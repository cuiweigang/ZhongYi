namespace ZhongYi.WuSe.WebApi.Api.ModelBinders
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Http.Controllers;
    using ZhongYi.WuSe.WebApi.Logic.Request;

    /// <summary>
    /// 公共参数绑定
    /// </summary>
    public class CommonRequestBinder : HttpParameterBinding
    {
        private struct AsyncVoid
        {
        }

        public CommonRequestBinder(HttpParameterDescriptor desc)
            : base(desc)
        {

        }

        /// <summary>
        /// 获取公共参数
        /// </summary>
        /// <param name="metadataProvider"></param>
        /// <param name="actionContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task ExecuteBindingAsync(System.Web.Http.Metadata.ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var common = new CommonRequest()
            {
                ApiVersion = GetParamterToString("ApiVersion"),
                Carrier = GetParamterToString("Carrier"),
                ClientVersion = GetParamterToString("ClientVersion"),
                ChannelId = GetParamterToString("ChannelId"),
                DeviceName = GetParamterToString("DeviceName"),
                IMEI = GetParamterToString("IMEI"),
                MacId = GetParamterToString("MacId"),
                SourcesId = GetParamterToString("SourcesId"),
                SessionId = GetParamterToString("SessionId"),
                ScreenWidth = GetParamterToString("ScreenWidth"),
                Ip = GetParamterToString("Ip"),
                OS = GetParamterToString("OS"),
                OSVersion = GetParamterToString("OSVersion"),
                Platform = GetParamterToString("Platform"),
                ScreenHeight = GetParamterToString("ScreenHeight"),
                WanType = GetParamterToString("WanType"),
            };

            // 添加用户ID
            if (HttpContext.Current.Items.Contains("CustomerId"))
            {
                common.CustomerId = TryInt(HttpContext.Current.Items["CustomerId"].ToString());
            }

            // TODO:根据Session获取用户ID

            SetValue(actionContext, common);
            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
            tcs.SetResult(null);
            return tcs.Task;
        }

        /// <summary>
        /// 获取字符类型的参数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string GetParamterToString(string key)
        {
            var value = HttpContext.Current.Request[key];
            return value ?? string.Empty;
        }

        /// <summary>
        /// 获取整型参数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int GetParamterToInt(string key)
        {
            var value = GetParamterToString(key);
            return TryInt(value);
        }

        /// <summary>
        /// TryInt
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int TryInt(string value)
        {
            int val;
            int.TryParse(value, out val);
            return val;
        }
    }
}