using System.Web;
using ZhongYi.WuSe.WebApi.Logic.Exceptions;
namespace ZhongYi.WuSe.WebApi.Api.Filters
{
    /// <summary>
    /// 授权验证Filter
    /// </summary>
    public class AuthorizeFilterAttribute : System.Web.Http.AuthorizeAttribute
    {
        protected override bool IsAuthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            /**
             * 1.排除不需要授权的Action直接通过
             * 2.需要验证的Action再次验证
             * **/
            // 排除无需授权Action
            var actionFilters = actionContext.ActionDescriptor.GetFilters();
            foreach (var f in actionFilters)
            {
                if (f is NoAuthorizeFilterAttribute)
                {
                    return true;
                }
            }

            // TODO:进行登录验证
            if (true)
            {
                // 传递用户ID
                HttpContext.Current.Items.Add("CustomerId", 13);

                return true;
            }

            throw new UnLoginedException();
        }
    }
}