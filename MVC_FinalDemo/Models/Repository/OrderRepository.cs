using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_FinalDemo.Models;
using MVC_FinalDemo.Models.Interface;

namespace MVC_FinalDemo.Models.Repository
{
    public class OrderRepository : IOrderRepository
    {
        protected dbEStoreEntities _db { get; private set; }
        public OrderRepository()
        {
            _db = new dbEStoreEntities();
        }
        public void Create(tOrder order)
        {
            if (order == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                _db.tOrder.Add(order);
                SaveChanges();
            }
        }

        public void Delete(tOrder order)
        {
            if (order == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                _db.Entry(order).State = System.Data.Entity.EntityState.Deleted;
                SaveChanges();
            }

        }

        public void DeleteRange(List<tOrder> orders)
        {
            _db.tOrder.RemoveRange(orders);
            SaveChanges();
        }


        public IEnumerable<tOrder> GetAll()
        {
            return _db.tOrder.ToList();
        }

        public IEnumerable<tOrder> GetByKeyword(string usr)
        {
            return _db.tOrder.Where(m => m.fOrderID.Contains(usr)).ToList();
        }

        public IEnumerable<tOrder> GetById(string oid)
        {
            return _db.tOrder.Where(m => m.fOrderID == oid).ToList();
        }



        public void Update(tOrder order)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}