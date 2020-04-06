using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC_FinalDemo.Models;

namespace MVC_FinalDemo.Controllers
{
    public class SetOrderStateController : ApiController
    {
        dbEStoreEntities db = new dbEStoreEntities();
        // GET: api/SetOrderState
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SetOrderState/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SetOrderState
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SetOrderState/5
        public bool Put(string oid, string state)
        {
            var odr = db.tOrder.Where(m=>m.fOrderID == oid).FirstOrDefault();
            odr.fState = state;
            db.SaveChanges();
            return true;
        }

        // DELETE: api/SetOrderState/5
        public void Delete(int id)
        {
        }
    }
}
