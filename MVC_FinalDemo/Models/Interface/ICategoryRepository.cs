using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_FinalDemo.Models.Interface
{
    public interface ICategoryRepository : IDisposable
    {
        void Create(tCatagory catagory);

        void Update(tCatagory catagory);

        void Delete(tCatagory catagory);

        tCatagory Get(int categoryID);

        tCatagory GetByName(string categoryName);

        IEnumerable<tCatagory> GetAll();


        void SaveChanges();
    }
}
