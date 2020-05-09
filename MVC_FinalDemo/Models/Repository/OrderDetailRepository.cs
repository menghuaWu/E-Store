using MVC_FinalDemo.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_FinalDemo.Models.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        protected dbEStoreEntities _db { get; private set; }
        public OrderDetailRepository()
        {
            _db = new dbEStoreEntities();
        }
        public void Create(tOrderDetail orderDetail)
        {
            if (orderDetail == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                _db.tOrderDetail.Add(orderDetail);
                SaveChanges();
            }
            
        }

        public void Delete(tOrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(List<tOrderDetail> orders)
        {
            _db.tOrderDetail.RemoveRange(orders);
            SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tOrderDetail> GetById(string oid)
        {
            return _db.tOrderDetail.Where(m => m.fOrderID == oid).ToList();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void Update(tOrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tOrderDetail> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}