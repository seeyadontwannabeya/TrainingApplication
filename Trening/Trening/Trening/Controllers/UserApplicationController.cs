using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Trening.Controllers
{
    public class UserApplicationController : ApiController
    {
        // GET: api/UserApplication
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UserApplication/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserApplication
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserApplication/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserApplication/5
        public void Delete(int id)
        {
        }
    }
}
