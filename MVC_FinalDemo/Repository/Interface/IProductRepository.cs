using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_FinalDemo.Models;

namespace MVC_FinalDemo.Repository.Interface
{
    public interface IProductRepository
    {
        void Create(tProduct product);

        void Update(tProduct product);

        void Delete(tProduct product);

        tProduct Get(int id);

        IEnumerable<tProduct> GetAll();

        void SaveChanges();
    }
}
