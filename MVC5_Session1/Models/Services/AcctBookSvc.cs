using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MVC5_Session1.Models
{
    public class AcctBookSvc
    {
        private MoneyEntity _db;
        public AcctBookSvc()
        {
            _db = new MoneyEntity();
        }

        public List<MoneyRecordViewModel> getRealData()
        {
            List<MoneyRecordViewModel> model = _db.AccountBook
                .Take(5)
                .Select(a => new MoneyRecordViewModel
                {
                    amount = a.Amounttt,
                    createDts = a.Dateee,
                    moneyType = (MoneyType)(a.Categoryyy + 1)  //Enum:1,2 Db:0,1
                }).ToList();
            return model;
        }

        /// <summary>
        /// 取得全部紀錄
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AccountBook> All()
        {
            return _db.AccountBook.ToList();
        }

        /// <summary>
        /// 取得一筆紀錄
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AccountBook Find(Guid id)
        {
            return _db.AccountBook.Find(id);
        }

        /// <summary>
        /// 新增一筆紀錄
        /// </summary>
        /// <param name="target"></param>
        public void Add(AccountBook target)
        {
            target.Dateee = DateTime.Now;
            _db.AccountBook.Add(target);
        }

        /// <summary>
        /// 修改一筆紀錄
        /// </summary>
        /// <param name="pageData"></param>
        /// <param name="target"></param>
        public void Edit(AccountBook pageData,AccountBook target)
        {
            target.Amounttt = pageData.Amounttt;
            target.Categoryyy = pageData.Categoryyy;
            target.Dateee = DateTime.Now;
            target.Remarkkk = pageData.Remarkkk;

        }

        /// <summary>
        /// 刪除一筆紀錄
        /// </summary>
        /// <param name="target"></param>
        public void Delete(AccountBook target)
        {
            _db.AccountBook.Remove(target);
        }

        /// <summary>
        /// 資料確認變更
        /// </summary>
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}