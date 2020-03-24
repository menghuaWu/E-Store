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
        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            return View(db.tProduct.ToList());
        }
    }
}