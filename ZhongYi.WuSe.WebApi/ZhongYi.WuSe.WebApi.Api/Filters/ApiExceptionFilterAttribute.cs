namespace ZhongYi.WuSe.WebApi.Api.Filters
{
    using System.Net;
    using System.Web;
    using System.Web.Http.Filters;
    using ZhongYi.WuSe.WebApi.Logic.Exceptions;
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
            // 先记录原始异常
            // 再进行异常处理
            var exception = actionExecutedContext.Exception;

            if (!(exception is BaseException))
            {
                exception = new InternalServerException();
            }

            var webApiExecption = exception as BaseException;

            var data = new CommonResponse()
            {
                Status = (int)webApiExecption.StatusCode,
                Description = webApiExecption.Message
            };

            HttpContext.Current.ClearError();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.StatusCode = (int)HttpStatusCode.OK;
            HttpContext.Current.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(data));
            HttpContext.Current.Response.End();


            //ILog log = LogManager.GetLogger(HttpContext.Current.Request.Url.LocalPath);
            //log.Error(context.Exception);

            //var message = context.Exception.Message;
            //if (context.Exception.InnerException != null)
            //    message = context.Exception.InnerException.Message;

            //context.Response = new HttpResponseMessage() { Content = new StringContent(message) };

            //base.OnException(context);
        }
    }
}