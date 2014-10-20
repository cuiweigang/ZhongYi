using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZhongYi.WuSe.WebApi.Logic.Request;
using ZhongYi.WuSe.WebApi.Logic.Response.Shop;

namespace ZhongYi.WuSe.WebApi.Api.Versions.V1.Controllers
{
    /// <summary>
    /// 店铺相关信息
    /// </summary>
    public class ShopController : ApiController
    {
        /// <summary>
        /// 店铺信息
        /// </summary>
        /// <param name="common"></param>
        /// <returns></returns>
        [AcceptVerbs("GET", "POST")]
        public ShopInfo Info(CommonRequest common)
        {
            return new ShopInfo { IsNew = true };
        }
    }
}
