using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_FinalDemo.Models.Interface
{
    public interface IRepository<TModel>
    {
        void Create(TModel product);

        void Update(TModel product);

        void Delete(TModel product);
        IEnumerable<TModel> GetAll();
        void SaveChanges();
    }
}
