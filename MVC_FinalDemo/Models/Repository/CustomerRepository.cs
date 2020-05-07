using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_FinalDemo.Models.Interface;

namespace MVC_FinalDemo.Models.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        protected dbEStoreEntities _db { get; private set; }
        public CustomerRepository()
        {
            _db = new dbEStoreEntities();
        }
        public void Create(tCustomer customer)
        {
            if (customer == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                _db.tCustomer.Add(customer);
                SaveChanges();
            }
        }

        public void Delete(tCustomer customer)
        {
            if (customer == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                _db.Entry(customer).State = System.Data.Entity.EntityState.Deleted;
                SaveChanges();
            }
            
        }

        

        public tCustomer Get(int id)
        {
            return _db.tCustomer.Find(id);
        }

        public IEnumerable<tCustomer> GetAll()
        {
            return _db.tCustomer.ToList();
        }

        public tCustomer GetByCustomerID(string customerId)
        {
            return _db.tCustomer.Where(m=>m.fCustomerID == customerId).FirstOrDefault();
        }

        public tCustomer GetByName(string customerName)
        {
            return _db.tCustomer.Where(m=>m.fCustomerName == customerName).FirstOrDefault();
        }

        

        public void Update(tCustomer customer)
        {
            if (customer == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                _db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                SaveChanges();
            }
            
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_db != null)
                {
                    _db.Dispose();
                    _db = null;
                }
            }
        }
    }
}