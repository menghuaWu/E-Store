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
    public class StoreController : Controller
    {
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private ICartRepository _cartRepository;
        private IOrderRepository _orderRepository;
        private IOrderDetailRepository _orderDetailRepository;

        public StoreController()
        {
            _productRepository = new ProductRepository();
            _categoryRepository = new CategoryRepository();
            _cartRepository = new CartRepository();
            _orderRepository = new OrderRepository();
            _orderDetailRepository = new OrderDetailRepository();
        }
        //dbEStoreEntities db = new dbEStoreEntities();
        ProductCategoryViewModel pcvm = new ProductCategoryViewModel();
        // GET: Store
        [Authorize]
        public ActionResult Index()
        {
            return View(_productRepository.GetAll());
        }

        [Authorize]
        public ActionResult AddtoCart(string pd)
        {
            //var cartItem = db.tCart.Where(m=>m.fProductName == pd && m.fCustomerName == User.Identity.Name).FirstOrDefault();
            var cartItem = _cartRepository.GetByProductNameAndUsr(pd, User.Identity.Name);
            if (cartItem != null)
            {
                cartItem.fProductCount++;
                cartItem.fTotalPrice = cartItem.fProductPrice * cartItem.fProductCount;
                //db.SaveChanges();
                _cartRepository.SaveChanges();
            }
            else
            {
                //var product = db.tProduct.Where(m=>m.fProductName == pd).FirstOrDefault();
                var product = _productRepository.GetByName(pd);
                tCart cart = new tCart()
                {
                    fCustomerName = User.Identity.Name,
                    fProductCount = 1,
                    fProductName = pd,
                    fProductPrice = product.fProductPrice,
                    fTotalPrice = product.fProductPrice * 1
                };
                //db.tCart.Add(cart);
                //db.SaveChanges();
                _cartRepository.Create(cart);
            }
            
            return RedirectToAction("Index", "Carts");
            
        }

        [Authorize]
        public ActionResult OrderInform()
        {
            var usr = User.Identity.Name;
            //var orders = db.tOrder.Where(m => m.fOrderID.Contains(usr)).ToList();
            var orders = _orderRepository.GetByKeyword(usr).ToList();
            return View(orders);
        }

        [Authorize]
        public ActionResult Delete(string oid)
        {
            //var order = db.tOrder.Where(m=>m.fOrderID == oid).ToList();
            var orders = _orderRepository.GetById(oid).ToList();
            //var orderDtl = db.tOrderDetail.Where(m => m.fOrderID == oid).ToList();
            var orderDtl = _orderDetailRepository.GetById(oid).ToList();
            //db.tOrder.RemoveRange(orders);
            _orderRepository.DeleteRange(orders);
            //db.tOrderDetail.RemoveRange(orderDtl);
            _orderDetailRepository.DeleteRange(orderDtl);
            //db.SaveChanges();
            return RedirectToAction("OrderInform");
        }

      
        public ActionResult Detail(int id=1)
        {
            //var catName = db.tCatagory.Where(m => m.Id == id).FirstOrDefault();
            var catName =  _categoryRepository.Get(id);
            //pcvm.Products = db.tProduct.Where(m=>m.fProductCatagory == catName.fName).ToList();
            pcvm.Products = _productRepository.GetAllByCategory(catName.fName).ToList();
            //pcvm.Category = db.tCatagory.ToList();
            pcvm.Category = _categoryRepository.GetAll().ToList();
            if (User.Identity.Name == "")
            {
                ViewBag.NoUser = true;
                return View("Detail", "_LayoutIndex", pcvm);
            }
            else
            {
                return View(pcvm);
            }
        }
    }
}