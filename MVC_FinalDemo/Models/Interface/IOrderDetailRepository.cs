using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_FinalDemo.Models.Interface
{
    public interface IOrderDetailRepository : IDisposable, IRepository<tOrderDetail>
    {


        IEnumerable<tOrderDetail> GetById(string oid);

        void DeleteRange(List<tOrderDetail> orders);

        
    }
}
