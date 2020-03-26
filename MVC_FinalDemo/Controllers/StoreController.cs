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
        ProductCategoryViewModel pcvm = new ProductCategoryViewModel();
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

        [Authorize]
        public ActionResult OrderInform()
        {
            var usr = User.Identity.Name;
            var orders = db.tOrder.Where(m => m.fOrderID.Contains(usr)).ToList();
            return View(orders);
        }

        [Authorize]
        public ActionResult Delete(string oid)
        {
            var order = db.tOrder.Where(m=>m.fOrderID == oid).ToList();
            var orderDtl = db.tOrderDetail.Where(m => m.fOrderID == oid).ToList();
            db.tOrder.RemoveRange(order);
            db.tOrderDetail.RemoveRange(orderDtl);
            db.SaveChanges();
            return RedirectToAction("OrderInform");
        }

        [Authorize]
        public ActionResult Detail(int id=1)
        {
            var catName = db.tCatagory.Where(m => m.Id == id).FirstOrDefault();
            pcvm.Products = db.tProduct.Where(m=>m.fProductCatagory == catName.fName).ToList();
            pcvm.Category = db.tCatagory.ToList();
            return View(pcvm);
        }
    }
}