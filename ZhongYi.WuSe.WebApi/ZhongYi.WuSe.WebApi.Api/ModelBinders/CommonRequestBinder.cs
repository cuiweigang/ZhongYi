using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace ZhongYi.WuSe.WebApi.Api.ModelBinders
{
    using System.Collections.Specialized;
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


    public HttpControllerDescriptor SelectController(HttpRequestMessage request)
{
            IHttpRouteData routeData = request.GetRouteData();
            if (routeData == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            // Get the namespace and controller variables from the route data.
            string namespaceName = GetRouteVariable<string>(routeData, “namespace”);
            if (namespaceName == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            string controllerName = GetRouteVariable<string>(routeData, “controller”);
            if (controllerName == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            // Find a matching controller.
            string key = String.Format(CultureInfo.InvariantCulture, "{0}.{1}", namespaceName, controllerName);

            HttpControllerDescriptor controllerDescriptor;
            if (_controllers.Value.TryGetValue(key, out controllerDescriptor))
            {
                return controllerDescriptor;
            }
            else if (_duplicates.Contains(key))
            {
                throw new HttpResponseException(
                    request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "Multiple controllers were found that match this request."));
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
}

// Get a value from the route data, if present.
private static T GetRouteVariable<t>(IHttpRouteData routeData, string name)
{
            object result = null;
            if (routeData.Values.TryGetValue(name, out result))
            {
                return (T)result;
            }
            return default(T);
}

    //public class ETagParameterBinding : HttpParameterBinding
    //{
    //    //ETagMatch _match;

    //    //public ETagParameterBinding(HttpParameterDescriptor parameter, ETagMatch match)
    //    //    : base(parameter)
    //    //{
    //    //    _match = match;
    //    //}

    //    //public override Task ExecuteBindingAsync(
    //    //    ModelMetadataProvider metadataProvider,
    //    //    HttpActionContext actionContext,
    //    //    CancellationToken cancellationToken)
    //    //{
    //    //    EntityTagHeaderValue etagHeader = null;
    //    //    switch (_match)
    //    //    {
    //    //        case ETagMatch.IfNoneMatch:          etagHeader = actionContext.Request.Headers.IfNoneMatch.FirstOrDefault(); break; case ETagMatch.IfMatch:          etagHeader = actionContext.Request.Headers.IfMatch.FirstOrDefault(); break;
    //    //    } ETag etag = null; if (etagHeader != null) { etag = new ETag { Tag = etagHeader.Tag }; }
    //    //    actionContext.ActionArguments[Descriptor.ParameterName] = etag;

    //    //    var tsc = new TaskCompletionSource<object>(); 
    //    //    tsc.SetResult(null);
    //    //    return tsc.Task;
    //    //}
    //}
}