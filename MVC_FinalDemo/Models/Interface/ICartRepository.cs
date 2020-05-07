using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_FinalDemo.Models.Interface
{
    public interface ICartRepository : IDisposable
    {
        void Create(tCart cart);

        void Update(tCart cart);

        void Delete(tCart cart);

        void DeleteRange(List<tCart> carts);

        tCart Get(int cartID);

        IEnumerable<tCart> GetByName(string usr);
        tCart GetByProductName(string pdName);

        tCart GetByProductNameAndUsr(string productName, string usrName);

        IEnumerable<tCart> GetAll();


        int SaveChanges();
    }
}
