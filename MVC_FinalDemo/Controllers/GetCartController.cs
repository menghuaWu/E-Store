using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC_FinalDemo.Models;
using MVC_FinalDemo.Models.Interface;
using MVC_FinalDemo.Models.Repository;

namespace MVC_FinalDemo.Controllers
{
    public class GetCartController : ApiController
    {
        private ICartRepository _cartRepository;
        private IProductRepository _productRepository;
        public GetCartController()
        {
            _cartRepository = new CartRepository();
            _productRepository = new ProductRepository();
        }
        //dbEStoreEntities db = new dbEStoreEntities();
        // GET: api/GetCart
        public int Get()
        {
            int count = 0;
            //var cart = db.tCart.ToList();
            var cart = _cartRepository.GetAll().ToList();
            foreach (var item in cart)
            {
                if (item.fProductCount == 1)
                {
                    count++;
                }
                else
                {
                    count += (int)item.fProductCount;
                }
            }
            return count;
        }

        // GET: api/GetCart/5
        public IEnumerable<tCart> Get(string cName)
        {
            //var carts = db.tCart.Where(m=>m.fCustomerName == cName).ToList();
            var carts = _cartRepository.GetByName(cName).ToList();
            return carts;
        }


        // POST: api/GetCart
        public bool Post(string pdName)
        {
            //var cartItem = db.tCart.Where(m => m.fProductName == pdName).FirstOrDefault();
            var cartItem = _cartRepository.GetByProductName(pdName);
            if (cartItem != null)
            {
                cartItem.fProductCount++;
                cartItem.fTotalPrice = cartItem.fProductPrice * cartItem.fProductCount;
                //db.SaveChanges();
                _cartRepository.SaveChanges();
            }
            else
            {
                //var product = db.tProduct.Where(m => m.fProductName == pdName).FirstOrDefault();
                var product = _productRepository.GetByName(pdName);
                tCart cart = new tCart()
                {
                    fCustomerName = User.Identity.Name,
                    fProductCount = 1,
                    fProductName = pdName,
                    fProductPrice = product.fProductPrice,
                    fTotalPrice = product.fProductPrice * 1
                };
                //db.tCart.Add(cart);
                _cartRepository.Create(cart);
                //db.SaveChanges();
            }
            return true;
        }

        // PUT: api/GetCart/5
        public bool Put(int id, string cName, string pName)
        {
            //var cart = db.tCart.Where(m => m.fCustomerName == cName && m.fProductName == pName).FirstOrDefault();
            var cart = _cartRepository.GetByProductNameAndUsr(pName, cName);
            var price = cart.fProductPrice;
            int k = 0;
            if (id == 0)
            {
                try
                {
                    
                    cart.fProductCount++;
                    cart.fTotalPrice = cart.fProductCount * cart.fProductPrice;
                    //k = db.SaveChanges();
                    k = _cartRepository.SaveChanges();
                }
                catch (Exception)
                {
                    k = 0;
                }
                
                if (k != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    if (cart.fProductCount == 1)
                    {
                        return false;
                    }
                    cart.fProductCount--;
                    cart.fTotalPrice = cart.fProductCount * cart.fProductPrice;
                    //k = db.SaveChanges();
                    k = _cartRepository.SaveChanges();
                }
                catch (Exception)
                {
                    k = 0;
                }
                if (k != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // DELETE: api/GetCart/5
        public bool Delete(string cName, string pName)
        {
            int k = 0;
            try
            {
                //var cart = db.tCart.Where(m => m.fCustomerName == cName && m.fProductName == pName).FirstOrDefault();
                var cart = _cartRepository.GetByProductNameAndUsr(pName, cName);
                //db.tCart.Remove(cart);
                _cartRepository.Delete(cart);
                //k = db.SaveChanges();
                k = _cartRepository.SaveChanges();
            }
            catch (Exception)
            {
                k = 0;
            }

            if (k != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
