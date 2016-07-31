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
            //TODO:正式上線需要抓真的資料
            //List<MoneyRecordViewModel> model = getRealData();
            List<MoneyRecordViewModel> model = getFakeData();

            return View(model);
        }
        /// <summary>
        /// 開發時期View所使用的假資料
        /// </summary>
        /// <returns></returns>
        private static List<MoneyRecordViewModel> getFakeData()
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
            return model;
        }
    }
}