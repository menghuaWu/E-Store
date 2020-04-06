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
        public List<SelectListItem> GetItem()
        {
            List<SelectListItem> ls = new List<SelectListItem>()
            {
                new SelectListItem{ Text="未出貨", Value="未出貨"},
                new SelectListItem{ Text="已出貨", Value="已出貨"},
                new SelectListItem{ Text="已到貨", Value="已到貨"},
                new SelectListItem{ Text="已付款", Value="已付款"}
            };

            return ls;
        }
        
        dbEStoreEntities db = new dbEStoreEntities();
        ProductCategoryViewModel pcvm = new ProductCategoryViewModel();
        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            if (User.Identity.Name == "root")
            {
                return View(db.tProduct.ToList());
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Product(int id=1)
        {
            if (User.Identity.Name != "root")
            {
                return RedirectToAction("Index", "Home");
            }
            var catName = db.tCatagory.Where(m => m.Id == id).FirstOrDefault();
            pcvm.Products = db.tProduct.Where(m => m.fProductCatagory == catName.fName).ToList();
            pcvm.Category = db.tCatagory.ToList();
            return View(pcvm);

        }

        [Authorize]
        public ActionResult Category()
        {
            return View(db.tCatagory.ToList());
        }

        [Authorize]
        public ActionResult CaCreate()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CaCreate(string fName)
        {
            var cats = db.tCatagory.Where(m=>m.fName == fName).FirstOrDefault();
            var count = db.tCatagory.ToList().Count();
            var cid = "A";
            
            if (cats == null)
            {
                if (count < 10)
                {
                    cid += "0";
                }
                tCatagory cat = new tCatagory { 
                    fCatagoryID = cid + (++count),
                    fName = fName,
                };
                db.tCatagory.Add(cat);
                db.SaveChanges();
                return RedirectToAction("Category");
            }
            ViewBag.isCate = true;
            return View();
        }

        [Authorize]
        public ActionResult CaEdit(string cid)
        {
            if (User.Identity.Name != "root")
            {
                return RedirectToAction("Index", "Home");
            }
            var catagory = db.tCatagory.Where(m=>m.fCatagoryID == cid).FirstOrDefault();
            return View(catagory);
        }

        [Authorize]
        [HttpPost]
        public ActionResult CaEdit(string fCatagoryID, string oldName, string fName)
        {
            if (User.Identity.Name != "root")
            {
                return RedirectToAction("Index", "Home");
            }
            var cats = db.tCatagory.Where(m=>m.fCatagoryID == fCatagoryID).FirstOrDefault();
            cats.fName = fName;
            var pds = db.tProduct.Where(m => m.fProductCatagory == oldName).ToList();
            foreach (var pd in pds)
            {
                pd.fProductCatagory = fName;
            }
            db.SaveChanges();
            return RedirectToAction("Category");
        }

        [Authorize]
        public ActionResult Member()
        {
            if (User.Identity.Name != "root")
            {
                return RedirectToAction("Index", "Home");
            }
            return View(db.tCustomer.ToList());
        }

        [Authorize]
        public ActionResult CEdit(string cid)
        {
            if (User.Identity.Name != "root")
            {
                return RedirectToAction("Index", "Home");
            }
            var cust = db.tCustomer.Where(m => m.fCustomerID == cid).FirstOrDefault();
            return View(cust);
        }

        [Authorize]
        [HttpPost]
        public ActionResult CEdit(tCustomer cus)
        {
            if (User.Identity.Name != "root")
            {
                return RedirectToAction("Index", "Home");
            }
            db.Entry(cus).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Member");
        }

        [Authorize]
        public ActionResult CDelete(string cid)
        {
            if (User.Identity.Name != "root")
            {
                return RedirectToAction("Index", "Home");
            }
            var cust = db.tCustomer.Where(m=>m.fCustomerID == cid).FirstOrDefault();
            db.Entry(cust).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Member");
        }

        [Authorize]
        public ActionResult Order()
        {
            if (User.Identity.Name != "root")
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Option = GetItem();
            return View(db.tOrder.ToList());
        }
        //[Authorize]
        //public ActionResult OEdit(string oid)
        //{

        //}

        [Authorize]
        public ActionResult ODelete( string oid)
        {
            var odr = db.tOrder.Where(m=>m.fOrderID == oid).FirstOrDefault();
            var odt = db.tOrderDetail.Where(m => m.fOrderID == oid).ToList();
            db.tOrderDetail.RemoveRange(odt);
            db.tOrder.Remove(odr);
            db.SaveChanges();
            return RedirectToAction("Order");
        }

        [Authorize]
        public ActionResult PEdit(string pd)
        {
            if (User.Identity.Name != "root")
            {
                return RedirectToAction("Index", "Home");
            }
            var product = db.tProduct.Where(m=>m.fProductName == pd).FirstOrDefault();
            ViewBag.Category = db.tCatagory.ToList();
            return View(product);
        }

        [Authorize]
        [HttpPost]
        public ActionResult PEdit(string fProductID, string fProductName, string fProductCatagory, int fProductPrice)
        {
            var pd = db.tProduct.Where(m => m.fProductID == fProductID).FirstOrDefault();
            pd.fProductName = fProductName;
            pd.fProductCatagory = fProductCatagory;
            pd.fProductPrice = fProductPrice;
            db.SaveChanges();
            return RedirectToAction("Product", new { id = 1 }) ;
        }
    }
}