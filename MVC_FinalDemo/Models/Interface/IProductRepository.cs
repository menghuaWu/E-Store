using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_FinalDemo.Models.Interface
{
    public interface IProductRepository : IDisposable
    {
        void Create(tProduct product);

        void Update(tProduct product);

        void Delete(tProduct product);

        tProduct Get(int productID);

        tProduct GetByName(string productName);

        IEnumerable<tProduct> GetAll();


        IEnumerable<tProduct> GetAllByCategory(string category);

        void SaveChanges();
    }
}
