using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZhongYi.WuSe.WebApi.Logic.Request;

namespace ZhongYi.WuSe.WebApi.Api.Versions.V2.Controllers
{
    using System.Web.Http.ModelBinding;

    public class DemoController : ApiController
    {
        public string Get(CommonRequest common, [ModelBinder]SignRequest sign, int customerId)
        {
            return common.OS + sign.OS + customerId;
        }
    }
}
