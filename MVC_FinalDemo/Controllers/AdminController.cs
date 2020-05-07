using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_FinalDemo.Models;
using MVC_FinalDemo.Models.Interface;
using MVC_FinalDemo.Models.Repository;

namespace MVC_FinalDemo.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private ICustomerRepository _customerRepository;
        private IOrderRepository _orderRepository;
        private IOrderDetailRepository _orderDetailRepository;
        public AdminController()
        {
            _productRepository = new ProductRepository();
            _categoryRepository = new CategoryRepository();
            _customerRepository = new CustomerRepository();
            _orderRepository = new OrderRepository();
            _orderDetailRepository = new OrderDetailRepository();
        }
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
        
        //dbEStoreEntities db = new dbEStoreEntities();
        ProductCategoryViewModel pcvm = new ProductCategoryViewModel();
        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            if (User.Identity.Name == "root")
            {
                return View(_productRepository.GetAll());
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
            //var catName = db.tCatagory.Where(m => m.Id == id).FirstOrDefault();
            var catName = _categoryRepository.Get(id);
            //pcvm.Products = db.tProduct.Where(m => m.fProductCatagory == catName.fName).ToList();
            pcvm.Products = _productRepository.GetAllByCategory(catName.fName).ToList();
            //pcvm.Category = db.tCatagory.ToList();
            pcvm.Category = _categoryRepository.GetAll().ToList();
            return View(pcvm);

        }

        [Authorize]
        public ActionResult Category()
        {
            return View(_categoryRepository.GetAll().ToList());
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
            //var cats = db.tCatagory.Where(m=>m.fName == fName).FirstOrDefault();
            var cats = _categoryRepository.GetByName(fName);
            //var count = db.tCatagory.ToList().Count();
            var count = _categoryRepository.GetAll().Count();
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
                //db.tCatagory.Add(cat);
                _categoryRepository.Create(cat);
                //db.SaveChanges();
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
            //var catagory = db.tCatagory.Where(m=>m.fCatagoryID == cid).FirstOrDefault();
            var category = _categoryRepository.GetByCategoryID(cid);
            return View(category);
        }

        [Authorize]
        [HttpPost]
        public ActionResult CaEdit(string fCatagoryID, string oldName, string fName)
        {
            if (User.Identity.Name != "root")
            {
                return RedirectToAction("Index", "Home");
            }
            //var cats = db.tCatagory.Where(m=>m.fCatagoryID == fCatagoryID).FirstOrDefault();
            var cats = _categoryRepository.GetByCategoryID(fCatagoryID);
            cats.fName = fName;
            _categoryRepository.Update(cats);
            //var pds = db.tProduct.Where(m => m.fProductCatagory == oldName).ToList();
            var pds = _productRepository.GetAllByCategory(oldName).ToList();
            foreach (var pd in pds)
            {
                pd.fProductCatagory = fName;
                _productRepository.Update(pd);
            }
            //db.SaveChanges();
            
            _productRepository.SaveChanges();
            return RedirectToAction("Category");
        }

        [Authorize]
        public ActionResult Member()
        {
            if (User.Identity.Name != "root")
            {
                return RedirectToAction("Index", "Home");
            }
            return View(_customerRepository.GetAll());
        }

        [Authorize]
        public ActionResult CEdit(string cid)
        {
            if (User.Identity.Name != "root")
            {
                return RedirectToAction("Index", "Home");
            }
            //var cust = db.tCustomer.Where(m => m.fCustomerID == cid).FirstOrDefault();
            var cust = _customerRepository.GetByCustomerID(cid);
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
            _customerRepository.Update(cus);
            //db.Entry(cus).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
            return RedirectToAction("Member");
        }

        [Authorize]
        public ActionResult CDelete(string cid)
        {
            if (User.Identity.Name != "root")
            {
                return RedirectToAction("Index", "Home");
            }
            //var cust = db.tCustomer.Where(m=>m.fCustomerID == cid).FirstOrDefault();
            var cust = _customerRepository.GetByCustomerID(cid);
            _customerRepository.Delete(cust);
            //db.Entry(cust).State = System.Data.Entity.EntityState.Deleted;
            //db.SaveChanges();
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
            return View(_orderRepository.GetAll().ToList());
        }


        [Authorize]
        public ActionResult ODelete( string oid)
        {
            //var odr = db.tOrder.Where(m=>m.fOrderID == oid).FirstOrDefault();
            var odr = _orderRepository.GetById(oid).FirstOrDefault();
            //var odt = db.tOrderDetail.Where(m => m.fOrderID == oid).ToList();
            var odt = _orderDetailRepository.GetById(oid).ToList();
            //db.tOrderDetail.RemoveRange(odt);
            _orderDetailRepository.DeleteRange(odt);
            //db.tOrder.Remove(odr);
            _orderRepository.Delete(odr);
            //db.SaveChanges();
            return RedirectToAction("Order");
        }

        [Authorize]
        public ActionResult PEdit(string pd)
        {
            if (User.Identity.Name != "root")
            {
                return RedirectToAction("Index", "Home");
            }
            //var product = db.tProduct.Where(m=>m.fProductName == pd).FirstOrDefault();
            var product = _productRepository.GetByName(pd);
            //ViewBag.Category = db.tCatagory.ToList();
            ViewBag.Category = _categoryRepository.GetAll();
            return View(product);
        }

        [Authorize]
        [HttpPost]
        public ActionResult PEdit(string fProductID, string fProductName, string fProductCatagory, int fProductPrice)
        {
            //var pd = db.tProduct.Where(m => m.fProductID == fProductID).FirstOrDefault();
            var pd = _productRepository.GetByProductID(fProductID);
            pd.fProductName = fProductName;
            pd.fProductCatagory = fProductCatagory;
            pd.fProductPrice = fProductPrice;
            //db.SaveChanges();
            _productRepository.SaveChanges();
            return RedirectToAction("Product", new { id = 1 }) ;
        }

        [Authorize]
        public ActionResult PDelete(string pd)
        {
            //var products = db.tProduct.Where(m => m.fProductName == pd).FirstOrDefault();
            var products = _productRepository.GetByName(pd);
            //db.tProduct.Remove(products);
            _productRepository.Delete(products);
            //db.SaveChanges();
            return RedirectToAction("Product", new { id = 1 });
        }

        [Authorize]
        public ActionResult PCreate()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult PCreate(string fProductName, string fProductCatagory, int fProductPrice)
        {
            //var pd = db.tProduct.Where(m => m.fProductName == fProductName).FirstOrDefault();
            var pd = _productRepository.GetByName(fProductName);
            if (pd != null)
            {
                ViewBag.IsProduct = true;
                return View();
            }
            string PID = "P";
            //var pCount = db.tProduct.ToList().Count();
            var pCount = _productRepository.GetAll().Count();
            if (pCount < 10)
            {
                PID += "00";
                PID += pCount;
            }
            else if (pCount < 100)
            {
                PID += "0";
                PID += pCount;
            }
            tProduct tpd = new tProduct() {
                fProductID = PID,
                fProductName = fProductName,
                fProductCatagory = fProductCatagory,
                fProductPrice = fProductPrice,
                fImg = "None"
            };
            //db.tProduct.Add(tpd);
            _productRepository.Create(tpd);
            //db.SaveChanges();
            return RedirectToAction("Product", new { id = 1 });
        }
    }
}