namespace ZhongYi.WuSe.WebApi.Api.ModelBinders
{
    using System;
    using System.Globalization;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Dispatcher;
    using System.Web.Http.Routing;

    public class CustomHttpControllerSelector : DefaultHttpControllerSelector
    {
        public CustomHttpControllerSelector(HttpConfiguration configuration)
            : base(configuration)
        {
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var _controllers = this.GetControllerMapping();
            IHttpRouteData routeData = request.GetRouteData();
            if (routeData == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            // Get the namespace and controller variables from the route data.
            string version = GetRouteVariable<string>(routeData, "version");

            if (string.IsNullOrEmpty(version))
            {
                return base.SelectController(request);
            }

            string controllerName = GetRouteVariable<string>(routeData, "controller");

            // 当controller不存在时
            if (controllerName == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            // 版本规则
            string key = String.Format(CultureInfo.InvariantCulture, "{0}_{1}", version, controllerName);

            // 查找Clntroller
            HttpControllerDescriptor controllerDescriptor;
            if (_controllers.TryGetValue(key, out controllerDescriptor))
            {
                return controllerDescriptor;
            }

            return base.SelectController(request);
        }

        // Get a value from the route data, if present.
        private static T GetRouteVariable<T>(IHttpRouteData routeData, string name)
        {
            object result = null;
            if (routeData.Values.TryGetValue(name, out result))
            {
                return (T)result;
            }
            return default(T);
        }
    }
}