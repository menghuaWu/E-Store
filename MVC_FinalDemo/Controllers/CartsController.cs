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
        //dbEStoreEntities db = new dbEStoreEntities();
        // GET: Carts
        [Authorize]
        public ActionResult Index()
        {
            //var usr = User.Identity.Name;
            //var carts = db.tCart.Where(m => m.fCustomerName == usr).ToList();
            return View();
        }
    }
}