using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC_FinalDemo.Models;

namespace MVC_FinalDemo.Controllers
{
    public class GetMemberController : ApiController
    {
        dbEStoreEntities db = new dbEStoreEntities();
        // GET: api/GetMember
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GetMember/5
        public tCustomer Get(string mid)
        {
            var member = db.tCustomer.Where(m => m.fCustomerID == mid).FirstOrDefault();

            return member;
        }

        // POST: api/GetMember
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GetMember/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GetMember/5
        public void Delete(int id)
        {
        }
    }
}
