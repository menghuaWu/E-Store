using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_FinalDemo.Models;

namespace MVC_FinalDemo.Controllers
{
    public class AdminController : Controller
    {
        dbEStoreEntities db = new dbEStoreEntities();
        ProductCategoryViewModel pcvm = new ProductCategoryViewModel();
        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            return View(db.tProduct.ToList());
        }

        [Authorize]
        public ActionResult Product(int id=1)
        {
            var catName = db.tCatagory.Where(m => m.Id == id).FirstOrDefault();
            pcvm.Products = db.tProduct.Where(m => m.fProductCatagory == catName.fName).ToList();
            pcvm.Category = db.tCatagory.ToList();
            return View(pcvm);

        }

        [Authorize]
        public ActionResult Edit(string pd)
        {
            var product = db.tProduct.Where(m=>m.fProductName == pd).FirstOrDefault();
            ViewBag.Opts = db.tCatagory.ToList();
            return View(product);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(tProduct cat)
        {
            var c = cat;
            return RedirectToAction("Product");
        }
    }
}