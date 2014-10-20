using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZhongYi.WuSe.WebApi.Logic.Request;

namespace ZhongYi.WuSe.WebApi.Api.Versions.V1.Controllers
{
    using ZhongYi.WuSe.WebApi.Api.Filters;
    using ZhongYi.WuSe.WebApi.Logic.Response;

    /// <summary>
    /// 账户API
    /// </summary>
    public class AccountsController : ApiController
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="common">公共参数</param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [AcceptVerbs("GET", "POST")]
        [NoAuthorizeFilter]
        public ApiResult Login(CommonRequest common, string name, string password)
        {
            return new ApiResult() { Success = true, Description = "登录成功" };
        }

        /// <summary>
        /// common
        /// </summary>
        /// <param name="common">公共参数</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "POST")]
        public ApiResult Logout(CommonRequest common)
        {
            return new ApiResult() { Success = true, Description = "退出成功" };
        }
    }
}
