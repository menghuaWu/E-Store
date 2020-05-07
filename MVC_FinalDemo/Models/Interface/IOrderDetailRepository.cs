using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_FinalDemo.Models.Interface
{
    public interface IOrderDetailRepository : IDisposable
    {
        void Create(tOrderDetail orderDetail);

        void Update(tOrderDetail orderDetail);

        void Delete(tOrderDetail orderDetail);

        IEnumerable<tOrderDetail> GetById(string oid);

        void DeleteRange(List<tOrderDetail> orders);

        void SaveChanges();
    }
}
