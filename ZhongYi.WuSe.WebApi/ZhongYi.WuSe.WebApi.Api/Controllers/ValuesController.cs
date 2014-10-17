namespace ZhongYi.WuSe.WebApi.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.Http.ModelBinding;
    using ZhongYi.WuSe.WebApi.Api.Filters;
    using ZhongYi.WuSe.WebApi.Api.ModelBinders;
    using ZhongYi.WuSe.WebApi.Logic.Exceptions;
    using ZhongYi.WuSe.WebApi.Logic.Request;

    public class ValuesController : ApiController
    {
        [AcceptVerbs("GET", "POST")]
        public IEnumerable<string> Add(CommonRequest common, [ModelBinder] SignRequest sign, int id = 0, string name = "")
        {
            List<string> list = new List<string>();
            list.Add(common.ApiVersion);
            list.Add(sign.OS);
            list.Add(id.ToString());
            list.Add(name);
            list.Add(common.CustomerId.ToString());
            return list;
        }

        [HttpGet]
        [HttpPost]
        public string GetName(string name)
        {
            return name;
        }

        // GET api/values/5
        [NoAuthorizeFilter]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}