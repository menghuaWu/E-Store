using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC_FinalDemo.Controllers
{
    public class RedirectController : ApiController
    {
        // GET: api/Redirect
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Redirect/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Redirect
        public IHttpActionResult Post()
        {
            return RedirectToRoute("Member/Login", null);
        }

        // PUT: api/Redirect/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Redirect/5
        public void Delete(int id)
        {
        }
    }
}
