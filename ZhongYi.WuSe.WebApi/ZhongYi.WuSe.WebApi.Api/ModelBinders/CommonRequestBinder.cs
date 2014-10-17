namespace ZhongYi.WuSe.WebApi.Api.ModelBinders
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.Controllers;

    using ZhongYi.WuSe.WebApi.Logic.Request;

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
            SetValue(actionContext, new CommonRequest() { OS = "123", ApiVersion = "321", CustomerId = 100000 });
            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
            tcs.SetResult(null);
            return tcs.Task;
        }
    }
}