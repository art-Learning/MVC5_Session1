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
            var model = new List<MoneyRecordViewModel>();
            model.Add(new MoneyRecordViewModel()
            {
                amount = 300,
                moneyType = MoneyType.Pay,
                createDts = DateTime.Now
            });
            model.Add(new MoneyRecordViewModel()
            {
                amount = 1600,
                moneyType = MoneyType.Pay,
                createDts = DateTime.Now.AddDays(1)
            });
            model.Add(new MoneyRecordViewModel()
            {
                amount = 800,
                moneyType = MoneyType.Pay,
                createDts = DateTime.Now.AddDays(2)
            });
            return View(model);
        }
    }
}