using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC_FinalDemo.Models;
using MVC_FinalDemo.Models.Interface;
using MVC_FinalDemo.Models.Repository;


namespace MVC_FinalDemo.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        public HomeController()
        {
            _productRepository = new ProductRepository();
            _categoryRepository = new CategoryRepository();
        }
        //dbEStoreEntities db = new dbEStoreEntities();
        void GetCatagory()
        {
            ViewBag.Catagory = _categoryRepository.GetAll();
        }
        // GET: Home
        public ActionResult Index()
        {
            GetCatagory();
            
            var products = _productRepository.GetAll();
            FormsAuthentication.SignOut();
            return View(products);
        }
    }
}