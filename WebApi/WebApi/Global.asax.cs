using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApi
{
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configuration.Formatters.Insert(0, new JsonpMediaTypeFormatter());
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            HttpContext.Current.Response.TrySkipIisCustomErrors = true;
            Server.ClearError();
            
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.StatusCode = 200;
            HttpContext.Current.Response.Write("{status=1,desc=\"参数不正确\"}");
            HttpContext.Current.Response.End();
        }
    }

    public class JsonpMediaTypeFormatter : JsonMediaTypeFormatter
    {
        public override Task WriteToStreamAsync(
            Type type,
            object value,
            Stream writeStream,
            HttpContent content,
            TransportContext transportContext)
        {
            this.WriteToStream(type, value, writeStream, content);
            return Task.FromResult<AsyncVoid>(new AsyncVoid());
        }

        /// <summary>
        /// 写入WriteToStream
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="writeStream"></param>
        /// <param name="content"></param>
        private void WriteToStream(
            Type type,
            object value,
            Stream writeStream,
            HttpContent content)
        {
            JsonSerializer serializer = JsonSerializer.Create(this.SerializerSettings);
            using (StreamWriter streamWriter = new StreamWriter(writeStream, this.SupportedEncodings.First()))
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(streamWriter) { CloseOutput = false })
            {
                serializer.Serialize(jsonTextWriter, new { status = 1, data = value });
            }
        }
        public override MediaTypeFormatter GetPerRequestFormatterInstance(
            Type type,
            HttpRequestMessage request,
            MediaTypeHeaderValue mediaType)
        {
            return new JsonpMediaTypeFormatter();
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        private struct AsyncVoid
        {
        }
    }
}
