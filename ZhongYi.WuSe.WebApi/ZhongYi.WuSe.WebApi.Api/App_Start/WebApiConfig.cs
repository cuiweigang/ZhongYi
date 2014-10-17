namespace ZhongYi.WuSe.WebApi.Api.App_Start
{
    using System.Linq;
    using System.Web.Http;

    using ZhongYi.WuSe.WebApi.Api.Filters;
    using ZhongYi.WuSe.WebApi.Api.Formatters;
    using ZhongYi.WuSe.WebApi.Api.ModelBinders;
    using ZhongYi.WuSe.WebApi.Logic.Request;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
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

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { controller = "values", action = "add", id = RouteParameter.Optional }
            );
        }
    }
}
