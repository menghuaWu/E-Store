using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC_FinalDemo.Models;

namespace MVC_FinalDemo.Controllers
{
    public class GetStoreController : ApiController
    {
        dbEStoreEntities db = new dbEStoreEntities();
        // GET: api/GetStore
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GetStore/5
        public IEnumerable<tOrderDetail> Get(string odr)
        {
            var dtl = db.tOrderDetail.Where(m=>m.fOrderID == odr).ToList();
            return dtl;
        }

        // POST: api/GetStore
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GetStore/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GetStore/5
        public void Delete(int id)
        {
        }
    }
}
