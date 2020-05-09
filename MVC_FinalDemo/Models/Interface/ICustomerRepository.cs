using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_FinalDemo.Models.Interface
{
    public interface ICustomerRepository : IDisposable, IRepository<tCustomer>
    {


        tCustomer Get(int id);

        tCustomer GetByName(string customerName);
        tCustomer GetByCustomerID(string customerId);

    }
}
