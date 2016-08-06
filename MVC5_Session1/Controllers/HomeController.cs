using MVC5_Session1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5_Session1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AcctBookSvc _acctBookSvc;

        public HomeController()
        {
            _acctBookSvc = new AcctBookSvc();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [ChildActionOnly]
        public ActionResult MoneyList()
        {
            //TODO:未來可能要接收搜尋引擎參數進行查詢動作
            var model = _acctBookSvc.getRealData();
            return View(model);
        }
    }
}