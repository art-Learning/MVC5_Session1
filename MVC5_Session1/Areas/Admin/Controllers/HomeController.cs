using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5_Session1.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}