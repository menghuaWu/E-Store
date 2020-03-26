using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_FinalDemo.Models;

namespace MVC_FinalDemo.Controllers
{
    public class CartsController : Controller
    {
        dbEStoreEntities db = new dbEStoreEntities();
        // GET: Carts
        [Authorize]
        public ActionResult Index()
        {
            //var usr = User.Identity.Name;
            //var carts = db.tCart.Where(m => m.fCustomerName == usr).ToList();
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Index(string custName, string custPhone, string custMail)
        {
            var usr = User.Identity.Name;
            var Index = db.tOrder.ToList().LongCount();
            var orderId = "OD" + Index + usr;
            tOrder odr = new tOrder()
            {
                fOrderID = orderId,
                fCustomerName = custName,
                fCustomerPhone = custPhone,
                fCustomerEmail = custMail,
                fDate = DateTime.Now.Date.ToString(),
                fState = "未出貨"
            };
            db.tOrder.Add(odr);
            var carts = db.tCart.Where(m => m.fCustomerName == usr).ToList();
            foreach (var item in carts)
            {
                var product = db.tProduct.Where(m => m.fProductName == item.fProductName).FirstOrDefault();
                tOrderDetail odd = new tOrderDetail()
                {
                    fOrderID = orderId,
                    fProductID = product.fProductID,
                    fProductName = item.fProductName,
                    fProductCount = item.fProductCount,
                    fProductPrice = item.fProductPrice,
                    fTotalPrice = item.fTotalPrice
                };
                db.tOrderDetail.Add(odd);
            }
            db.tCart.RemoveRange(carts);

            db.SaveChanges();
            return RedirectToAction("OrderInform", "Store");
        }
    }
}