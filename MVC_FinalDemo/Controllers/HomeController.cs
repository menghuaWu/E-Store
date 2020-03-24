using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_FinalDemo.Models;

namespace MVC_FinalDemo.Controllers
{
    public class HomeController : Controller
    {
        dbEStoreEntities db = new dbEStoreEntities();
        void GetCatagory()
        {
            ViewBag.Catagory = db.tCatagory.ToList();
        }
        // GET: Home
        public ActionResult Index()
        {
            GetCatagory();
            var products = db.tProduct.ToList();
            return View(products);
        }
    }
}