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
        private MoneyEntity db = new MoneyEntity();

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
            List<MoneyRecordViewModel> model = getFakeData();
            //List<MoneyRecordViewModel> model = getRealData();
            return View(model);
        }

        private List<MoneyRecordViewModel> getRealData()
        {
            List<MoneyRecordViewModel> model = db.AccountBook
                .Take(5)
                .Select(a => new MoneyRecordViewModel
                {
                    amount = a.Amounttt,
                    createDts = a.Dateee,
                    moneyType = (MoneyType)(a.Categoryyy+1)  //Enum:1,2 Db:0,1
                }).ToList();
            return model;
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