using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC_FinalDemo.Models;
using MVC_FinalDemo.Models.Interface;
using MVC_FinalDemo.Models.Repository;

namespace MVC_FinalDemo.Controllers
{
    public class GetStoreController : ApiController
    {
        private IOrderDetailRepository _orderDetailRepository;
        public GetStoreController()
        {
            _orderDetailRepository = new OrderDetailRepository();
        }
        //dbEStoreEntities db = new dbEStoreEntities();
        // GET: api/GetStore
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GetStore/5
        public IEnumerable<tOrderDetail> Get(string odr)
        {
            //var dtl = db.tOrderDetail.Where(m=>m.fOrderID == odr).ToList();
            var dtl = _orderDetailRepository.GetById(odr).ToList();
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
