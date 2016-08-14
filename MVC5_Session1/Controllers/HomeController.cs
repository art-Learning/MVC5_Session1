using MVC5_Session1.Models;
using MVC5_Session1.Models.ViewModel;
using MVC5_Session1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5_Session1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AcctBookSvc _acctSvc;

        public HomeController()
        {
            var unitOfWork = new EFUnitOfWork();
            _acctSvc = new AcctBookSvc(unitOfWork);
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
        public ActionResult AcctBook()
        {
            return View();
        }
        /// <summary>
        /// 方案一：氣滿紅血招式放大絕
        /// </summary>
        /// <param name="frm">表單傳送資料</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AcctBook(FormCollection frm)
        {
            AccountBook target = _acctSvc.ConvToObjByFrm(frm);
            if (target != null)
            {
                _acctSvc.Add(target);
                _acctSvc.Save();
            }
            return View();
        }

        public ActionResult AcctBook2()
        {
            ViewData["ddl"] = createFormDropDownList();

            return View();
        }
        /// <summary>
        /// 製作記帳本表單的下拉選單
        /// </summary>
        /// <returns></returns>
        private IEnumerable<SelectListItem> createFormDropDownList()
        {
            var options = new List<MoneyDDL>();
            options.Add(new MoneyDDL() { Text = "請選擇", Value = "" });
            options.Add(new MoneyDDL() { Text = "支出", Value = "1" });
            options.Add(new MoneyDDL() { Text = "收入", Value = "0" });
            return new SelectList(options, "Value", "Text");
        }

        /// <summary>
        /// 方案二：用ViewModel接資料
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AcctBook2(
            [Bind(Include ="category,money,date,description")]
            MoneyFormViewModel vm)
        {
            if (ModelState.IsValid)
            {
                AccountBook target = _acctSvc.ConvToObjByVm(vm);
                if (target != null)
                {
                    _acctSvc.Add(target);
                    _acctSvc.Save();
                    return RedirectToAction("Index");
                }
            }
            ViewData["ddl"] = createFormDropDownList();
            return View(vm);
        }


        public ActionResult AcctBook3()
        {
            ViewData["ddl"] = createFormDropDownList();
            return View();
        }
        [HttpPost]
        public ActionResult AjaxPost([Bind(Include ="category,money,date,description")] MoneyFormViewModel vm)
        {
            if (ModelState.IsValid)
            {
                AccountBook target = _acctSvc.ConvToObjByVm(vm);
                if (target != null)
                {
                    _acctSvc.Add(target);
                    _acctSvc.Save();
                }
            }

            var model = _acctSvc.getRealData();
            return View(model);
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [ChildActionOnly]
        public ActionResult MoneyList()
        {
            var model = _acctSvc.getRealData();
            return View(model);
        }
    }
}