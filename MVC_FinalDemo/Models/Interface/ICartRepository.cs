using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_FinalDemo.Models.Interface
{
    public interface ICartRepository : IDisposable, IRepository<tCart>
    {
        

        void DeleteRange(List<tCart> carts);

        tCart Get(int cartID);

        IEnumerable<tCart> GetByName(string usr);
        tCart GetByProductName(string pdName);

        tCart GetByProductNameAndUsr(string productName, string usrName);



        int Save();
    }
}
