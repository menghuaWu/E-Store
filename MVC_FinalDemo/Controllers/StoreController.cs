using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_FinalDemo.Models;

namespace MVC_FinalDemo.Controllers
{
    public class StoreController : Controller
    {
        dbEStoreEntities db = new dbEStoreEntities();
        // GET: Store
        [Authorize]
        public ActionResult Index()
        {
            return View(db.tProduct.ToList());
        }

        [Authorize]
        public ActionResult AddtoCart(string pd)
        {
            var cartItem = db.tCart.Where(m=>m.fProductName == pd).FirstOrDefault();
            if (cartItem != null)
            {
                cartItem.fProductCount++;
                cartItem.fTotalPrice = cartItem.fProductPrice * cartItem.fProductCount;
                db.SaveChanges();
            }
            else
            {
                var product = db.tProduct.Where(m=>m.fProductName == pd).FirstOrDefault();
                tCart cart = new tCart()
                {
                    fCustomerName = User.Identity.Name,
                    fProductCount = 1,
                    fProductName = pd,
                    fProductPrice = product.fProductPrice,
                    fTotalPrice = product.fProductPrice * 1
                };
                db.tCart.Add(cart);
                db.SaveChanges();
            }
            
            return RedirectToAction("Index", "Carts");
            
        }
    }
}