using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_FinalDemo.Models.Interface
{
    public interface ICustomerRepository : IDisposable
    {
        
        void Create(tCustomer customer);

        void Update(tCustomer customer);

        void Delete(tCustomer customer);

        tCustomer Get(int id);

        tCustomer GetByName(string customerName);
        tCustomer GetByCustomerID(string customerId);

        IEnumerable<tCustomer> GetAll();


        void SaveChanges();
    }
}
