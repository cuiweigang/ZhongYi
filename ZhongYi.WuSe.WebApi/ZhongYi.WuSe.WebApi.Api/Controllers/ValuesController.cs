namespace ZhongYi.WuSe.WebApi.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;

    using ZhongYi.WuSe.WebApi.Logic.Exceptions;

    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            throw new ArgumentNullException();

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
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