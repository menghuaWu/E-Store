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
    public class CartsController : Controller
    {
        private ICartRepository _cartRepository;
        private IOrderRepository _orderRepository;
        private IOrderDetailRepository _orderDetailRepository;
        private IProductRepository _productRepository;
        public CartsController()
        {
            _cartRepository = new CartRepository();
            _orderRepository = new OrderRepository();
            _orderDetailRepository = new OrderDetailRepository();
            _productRepository = new ProductRepository();
        }
        //dbEStoreEntities db = new dbEStoreEntities();
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
            //var Index = db.tOrder.ToList().LongCount();
            var Index = _orderRepository.GetAll().LongCount();
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
            //db.tOrder.Add(odr);
            _orderRepository.Create(odr);
            //var carts = db.tCart.Where(m => m.fCustomerName == usr).ToList();
            var carts = _cartRepository.GetByName(usr).ToList();
            foreach (var item in carts)
            {
                //var product = db.tProduct.Where(m => m.fProductName == item.fProductName).FirstOrDefault();
                var product = _productRepository.GetByName(item.fProductName);
                tOrderDetail odd = new tOrderDetail()
                {
                    fOrderID = orderId,
                    fProductID = product.fProductID,
                    fProductName = item.fProductName,
                    fProductCount = item.fProductCount,
                    fProductPrice = item.fProductPrice,
                    fTotalPrice = item.fTotalPrice
                };
                //db.tOrderDetail.Add(odd);
                _orderDetailRepository.Create(odd);
            }
            //db.tCart.RemoveRange(carts);
            _cartRepository.DeleteRange(carts);
            //db.SaveChanges();
            return RedirectToAction("OrderInform", "Store");
        }
    }
}