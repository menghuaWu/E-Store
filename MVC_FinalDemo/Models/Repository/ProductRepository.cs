using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_FinalDemo.Models.Interface;

namespace MVC_FinalDemo.Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        protected dbEStoreEntities _db { get; private set; }
        public ProductRepository()
        {
            _db = new dbEStoreEntities();
        }
        public void Create(tProduct product)
        {
            if (product == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                _db.tProduct.Add(product);
                SaveChanges();
            }
        }

        public void Delete(tProduct product)
        {
            if (product == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                _db.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                SaveChanges();
            }
        }

        public tProduct Get(int productID)
        {
            return _db.tProduct.Find(productID);
        }

        public tProduct GetByName(string productName)
        {
            return _db.tProduct.Where(m => m.fProductName == productName).FirstOrDefault();
        }

        public IEnumerable<tProduct> GetAll()
        {
            return _db.tProduct.OrderBy(x => x.fProductID).ToList();
        }

        public IEnumerable<tProduct> GetAllByCategory(string category)
        {
            return _db.tProduct.Where(m => m.fProductCatagory == category).ToList();
        }


        public void Update(tProduct product)
        {
            if (product == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                _db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
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