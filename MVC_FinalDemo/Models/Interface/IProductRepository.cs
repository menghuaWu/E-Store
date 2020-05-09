using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_FinalDemo.Models.Interface
{
    public interface IProductRepository : IDisposable, IRepository<tProduct>
    {
        

        tProduct Get(int productID);

        tProduct GetByName(string productName);
        tProduct GetByProductID(string productID);

        


        IEnumerable<tProduct> GetAllByCategory(string category);

        
    }
}
