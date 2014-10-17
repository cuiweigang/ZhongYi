namespace ZhongYi.WuSe.WebApi.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http.Formatting;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using ZhongYi.WuSe.WebApi.Api.App_Start;
    using ZhongYi.WuSe.WebApi.Logic.Exceptions;

    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        /// <summary>
        /// 应用程序错误处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            //// 记录错误日志
            //// 返回相关异常情况
            //var exception = Server.GetLastError();
            //HttpContext.Current.Response.TrySkipIisCustomErrors = true;
            //HttpContext.Current.ClearError();
            //var desc = "";
            //var code = 200;

            //if (exception is ServerErrorException)
            //{
            //    desc = "出错了";
            //    code = 500;
            //}

            //Server.ClearError();

            //HttpContext.Current.Response.Clear();
            //HttpContext.Current.Response.StatusCode = 200;
            //HttpContext.Current.Response.Write(string.Format("{status={0},desc=\"{1}\"}", code, desc));
            //HttpContext.Current.Response.End();
        }
    }
}