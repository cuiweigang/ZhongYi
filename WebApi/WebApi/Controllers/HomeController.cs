using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Controllers
{
    using System.Text;
    using System.Web.Http;

    public class HomeController : Controller
    {
        /// <summary>
        /// 你好
        /// </summary>
        /// <returns></returns>
        public ContentResult Index()
        {
            return new ContentResult();
        }
    }

    /// <summary>
    /// result
    /// </summary>
    public class Test : ActionResult
    {
        public object Data { get; set; }

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            var result = new Result() { Data = Data, Status = 1 };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            context.HttpContext.Response.Write(json);
        }
    }

    public class Result
    {
        public int Status { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }
    }
}
