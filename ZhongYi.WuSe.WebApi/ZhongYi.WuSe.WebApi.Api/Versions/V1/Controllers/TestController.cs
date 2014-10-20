using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ZhongYi.WuSe.WebApi.Api.Versions.V1.Controllers
{
    using System.Web.Http.ModelBinding;
    using ZhongYi.WuSe.WebApi.Logic.Exceptions;
    using ZhongYi.WuSe.WebApi.Logic.Request;

    public class TestController : ApiController
    {
        public Dictionary<string, object> Get(CommonRequest common, [ModelBinder] SignRequest sign)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("Platform", common.Platform);
            dict.Add("Ip", common.Ip);
            dict.Add("OS", common.OS);
            dict.Add("OSVersion", common.OSVersion);
            dict.Add("ScreenHeight", common.ScreenHeight);
            dict.Add("ScreenWidth", common.ScreenWidth);
            dict.Add("SessionId", common.SessionId);
            dict.Add("SourcesId", common.SourcesId);
            dict.Add("MacId", common.MacId);
            dict.Add("IMEI", common.IMEI);
            dict.Add("DeviceName", common.DeviceName);
            dict.Add("CustomerId", common.CustomerId);
            dict.Add("ClientVersion", common.ClientVersion);
            dict.Add("ChannelId", common.ChannelId);
            dict.Add("Carrier", common.Carrier);
            dict.Add("ApiVersion", common.ApiVersion);

            dict.Add("TimeReq", sign.TimeReq);

            return dict;

        }
    }
}
