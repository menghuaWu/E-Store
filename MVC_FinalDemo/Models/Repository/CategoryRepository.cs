using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_FinalDemo.Models.Interface;

namespace MVC_FinalDemo.Models.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        protected dbEStoreEntities _db { get; private set; }
        public CategoryRepository()
        {
            _db = new dbEStoreEntities();
        }
        public void Create(tCatagory catagory)
        {
            if (catagory == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                _db.tCatagory.Add(catagory);
                SaveChanges();
            }
            
        }

        public void Delete(tCatagory catagory)
        {
            if (catagory == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                _db.Entry(catagory).State = System.Data.Entity.EntityState.Deleted;
                SaveChanges();
            }
            
        }

        
        public tCatagory Get(int categoryID)
        {
            return _db.tCatagory.Find(categoryID);
        }

        public IEnumerable<tCatagory> GetAll()
        {
            return _db.tCatagory.OrderBy(m => m.fCatagoryID).ToList();
        }

        public tCatagory GetByName(string categoryName)
        {
            return _db.tCatagory.Where(m => m.fName == categoryName).FirstOrDefault();
        }


        public void Update(tCatagory catagory)
        {
            if (catagory == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                _db.Entry(catagory).State = System.Data.Entity.EntityState.Modified;
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