using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_FinalDemo.Models.Interface;
using MVC_FinalDemo.Models;

namespace MVC_FinalDemo.Models.Repository
{
    public class CartRepository : ICartRepository
    {
        protected dbEStoreEntities _db { get; private set; }
        public CartRepository()
        {
            _db = new dbEStoreEntities();
        }
        public void Create(tCart cart)
        {
            if (cart == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                _db.tCart.Add(cart);
                Save();
            }
        }

        public void Delete(tCart cart)
        {
            if (cart == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                _db.Entry(cart).State = System.Data.Entity.EntityState.Deleted;
                //SaveChanges();
            }
        }

        public void DeleteRange(List<tCart> carts)
        {
            _db.tCart.RemoveRange(carts);
            Save();
        }
        public tCart Get(int cartID)
        {
            return _db.tCart.Find(cartID);
        }

        public IEnumerable<tCart> GetAll()
        {
            return _db.tCart.ToList();
        }

        public IEnumerable<tCart> GetByName(string usr)
        {
            return _db.tCart.Where(m => m.fCustomerName == usr).ToList();
        }

        public tCart GetByProductName(string pdName)
        {
            return _db.tCart.Where(m => m.fProductName == pdName).FirstOrDefault();
        }


        public tCart GetByProductNameAndUsr(string productName, string usrName)
        {
            return _db.tCart.Where(m => m.fProductName == productName && m.fCustomerName == usrName).FirstOrDefault();
        }


        public void Update(tCart cart)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            int k = 0;
            k = _db.SaveChanges();
            return k;
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

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}