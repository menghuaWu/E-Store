using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_FinalDemo.Models;
using System.Web.Security;


namespace MVC_FinalDemo.Controllers
{
    public class MemberController : Controller
    {
        
        
        dbEStoreEntities db = new dbEStoreEntities();

        [Authorize]
        public ActionResult Edit()
        {
            var cust = from m in db.tCustomer
                       where m.fCustomerName == User.Identity.Name
                       select m;
                
            return View(cust.FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(tCustomer cus)
        {
            db.Entry(cus).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            TempData["Message"] = "請重新登入";
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        // GET: Member
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string fCustomerName, string fCustomerPassword)
        {
            var root = db.tAdmin.Where(m=>m.fName == fCustomerName && m.fPassword == fCustomerPassword).FirstOrDefault();
            if (root != null)
            {
                FormsAuthentication.RedirectFromLoginPage(root.fName, false);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                var member = db.tCustomer.Where(m => m.fCustomerName == fCustomerName && m.fCustomerPassword == fCustomerPassword).FirstOrDefault();
                if (member != null)
                {
                    FormsAuthentication.RedirectFromLoginPage(member.fCustomerName, false);
                    return RedirectToAction("Index", "Store");
                }
                else
                {
                    ViewBag.NotMember = true;
                    return View();
                    //return RedirectToAction("Index", "Home");
                }
            }
            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(tCustomer customer)
        {
            var cus = db.tCustomer.Where(m=>m.fCustomerName == customer.fCustomerName).FirstOrDefault();
            if (cus != null)
            {
                ViewBag.Member = true;
                return View();
            }
            else
            {
                var hashTxt = GetTxt();
                customer.fCustomerID = hashTxt;
                db.tCustomer.Add(customer);
                db.SaveChanges();
                ViewBag.Adding = "註冊成功!請登入網站";
                return View();
            }
        }

        string GetTxt()
        {
            string head = "M";
            var d = db.tCustomer.ToList();
            var c = d.LongCount();
            head += c;
            return head;
        }
    }

}