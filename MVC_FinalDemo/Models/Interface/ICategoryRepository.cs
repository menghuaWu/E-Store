using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_FinalDemo.Models.Interface
{
    public interface ICategoryRepository : IDisposable, IRepository<tCatagory>
    {
       

        tCatagory Get(int categoryID);

        tCatagory GetByName(string categoryName);
        tCatagory GetByCategoryID(string categoryID);

    }
}
