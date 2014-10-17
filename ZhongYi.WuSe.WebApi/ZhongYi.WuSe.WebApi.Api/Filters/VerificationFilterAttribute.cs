using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZhongYi.WuSe.WebApi.Api.Filters
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Filters;

    using ZhongYi.WuSe.WebApi.Logic.Exceptions;
    using ZhongYi.WuSe.WebApi.Logic.Request;

    /// <summary>
    /// 验签Filter
    /// </summary>
    public class VerificationFilterAttribute : FilterAttribute, IActionFilter
    {
        public System.Threading.Tasks.Task<HttpResponseMessage> ExecuteActionFilterAsync(System.Web.Http.Controllers.HttpActionContext actionContext, System.Threading.CancellationToken cancellationToken, Func<System.Threading.Tasks.Task<HttpResponseMessage>> continuation)
        {
            // TODO:增加验签开关

            //SignRequest
            var sign = new SignRequest();
            sign.TimeReq = HttpContext.Current.Request["timereq"];
            sign.SignType = HttpContext.Current.Request["signtype"];
            sign.OS = HttpContext.Current.Request["os"];
            sign.Sign = HttpContext.Current.Request["sign"];

            // 验签通过 继续向下执行
            if (sign.Validate())
            {
                return continuation();
            }

            throw new UnauthorizedException();
        }
    }
}