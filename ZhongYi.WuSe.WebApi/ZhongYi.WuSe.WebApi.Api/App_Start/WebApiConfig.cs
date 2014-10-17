namespace ZhongYi.WuSe.WebApi.Api.App_Start
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Dispatcher;

    using ZhongYi.WuSe.WebApi.Api.Filters;
    using ZhongYi.WuSe.WebApi.Api.Formatters;
    using ZhongYi.WuSe.WebApi.Api.ModelBinders;
    using ZhongYi.WuSe.WebApi.Logic.Request;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // 使用自定义控制选择器
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerSelector), new CustomHttpControllerSelector(GlobalConfiguration.Configuration));

            // 参数绑定器
            config.ParameterBindingRules.Insert(0, param =>
            {
                if (param.ParameterType == typeof(CommonRequest))
                {
                    return new CommonRequestBinder(param);
                }
                return null;
            });

            // 注册自定义Json格式媒体
            config.Formatters.Insert(0, new JsonFactoryMediaTypeFormatter());
            config.Formatters.Add(new ApiJsonMediaTypeFormatter());
            config.Formatters.Add(new JsonpMediaTypeFormatter());

            // 注册WebApi异常
            config.Filters.Add(new ApiExceptionFilterAttribute());
            config.Filters.Add(new VerificationFilterAttribute());
            config.Filters.Add(new AuthorizeFilterAttribute());

            // 移除XML数据媒体格式
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // 路由规则
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{version}/{controller}/{action}",
                defaults: new { version = string.Empty, id = RouteParameter.Optional }
            );
        }
    }
}
