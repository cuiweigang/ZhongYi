namespace ZhongYi.WuSe.WebApi.Api.Filters
{
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    using ZhongYi.WuSe.WebApi.Api.Helpers;
    using ZhongYi.WuSe.WebApi.Logic.Exceptions;
    using ZhongYi.WuSe.WebApi.Logic.Helpers;
    using ZhongYi.WuSe.WebApi.Logic.Response;

    /// <summary>
    /// 异常过滤器
    /// </summary>
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// OnException
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            LoggerHelper.Error(actionExecutedContext.Exception);

            var json = ApiJsonFormatterHelper.ToJson(actionExecutedContext.Exception);

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(json);
            HttpContext.Current.Response.End();
        }
    }
}