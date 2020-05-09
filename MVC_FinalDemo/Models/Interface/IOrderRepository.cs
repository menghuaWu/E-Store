using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_FinalDemo.Models.Interface
{
    public interface IOrderRepository : IDisposable, IRepository<tOrder>
    {
        

        IEnumerable<tOrder> GetByKeyword(string usr);
        IEnumerable<tOrder> GetById(string oid);
        

        void DeleteRange(List<tOrder> orders);

        
    }
}
