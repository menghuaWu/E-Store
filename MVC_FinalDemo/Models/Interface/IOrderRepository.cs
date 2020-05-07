using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_FinalDemo.Models.Interface
{
    public interface IOrderRepository : IDisposable
    {
        void Create(tOrder order);

        void Update(tOrder order);

        void Delete(tOrder order);

        IEnumerable<tOrder> GetByKeyword(string usr);
        IEnumerable<tOrder> GetById(string oid);
        IEnumerable<tOrder> GetAll();

        void DeleteRange(List<tOrder> orders);

        void SaveChanges();
    }
}
