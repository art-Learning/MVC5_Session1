using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5_Session1.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        private const string ROLE_ADMIN = "admin";
        private const string ROLE_USER = "user";
        public ActionResult Index()
        {
            //無權限，回首頁
            if (User.IsInRole(ROLE_ADMIN))
            {
                return View();
            }
            return RedirectToAction("index", "Home", new { Area = "" });
        }
    }
}