using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    using System.Runtime.Serialization;

    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public Customer Get(int id)
        {
            throw new ArgumentNullException("exception");
            return new Customer { Id = 10, Name = "cuiweigang" };
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

    [DataContract]
    public class Customer
    {
        /// <summary>
        /// id
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// id
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}