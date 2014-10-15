namespace ZhongYi.WuSe.WebApi.Api.App_Start
{
    using System.Linq;
    using System.Web.Http;

    using ZhongYi.WuSe.WebApi.Api.Formatters;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.Insert(0, new JsonFactoryMediaTypeFormatter());
            config.Formatters.Add(new ApiJsonMediaTypeFormatter());
            config.Formatters.Add(new JsonpMediaTypeFormatter());

            // 移除XML数据媒体格式
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
