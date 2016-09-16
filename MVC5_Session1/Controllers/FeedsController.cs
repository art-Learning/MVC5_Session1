using MVC5_Session1.CustomResults;
using MVC5_Session1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;

namespace MVC5_Session1.Controllers
{
    public class FeedsController : Controller
    {
        private MoneyEntity db = new MoneyEntity();

        public ActionResult Index()
        {
            var feed = this.GetFeedData();
            return new RSSResult(feed);
        }

        private SyndicationFeed GetFeedData()
        {
            var feed = new SyndicationFeed(
                           "記帳本",
                           "RSS！",
                           new Uri(Url.Action("Rss", "Feed", null, "http")));

            var items = new List<SyndicationItem>();

            var acctRecs = db.AccountBook
                .Where(x => x.Dateee <= DateTime.Now)
                .OrderByDescending(x => x.Dateee);

            foreach (var rec in acctRecs)
            {
                var item = new SyndicationItem(
                    rec.Dateee.ToString("yyyy-MM-dd"),
                    (rec.Categoryyy==0 ? "收入:":"支出:") + rec.Amounttt,
                    new Uri(Url.Action("Detail", "Home", new { id = rec.Id }, "http")),     //TODO:未實作記帳本明細
                    "ID",
                    DateTime.Now);

                items.Add(item);
            }

            feed.Items = items;
            return feed;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}