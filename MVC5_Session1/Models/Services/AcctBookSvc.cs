using MVC5_Session1.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MVC5_Session1.Models
{
    public class AcctBookSvc : Repository<AccountBook>
    {
        private readonly IRepository<AccountBook> _acctRep;


        public AcctBookSvc(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _acctRep = new Repository<AccountBook>(unitOfWork);
        }

        public List<MoneyRecordViewModel> getRealData()
        {
            List<MoneyRecordViewModel> model = _acctRep.LookupAll()
                .Select(a => new MoneyRecordViewModel
                {
                    amount = a.Amounttt,
                    createDts = a.Dateee,
                    moneyType = (MoneyType)(a.Categoryyy + 1)  //Enum:1,2 Db:0,1
                }).OrderByDescending(a=>a.createDts)
                .ToList();
            return model;
        }

        /// <summary>
        /// 取得全部紀錄
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AccountBook> All()
        {
            return _acctRep.LookupAll();
        }

        /// <summary>
        /// 將表單資料塞進記帳本物件
        /// </summary>
        /// <param name="frm">表單資料</param>
        /// <returns>驗證通過返回物件，失敗返回null</returns>
        internal AccountBook ConvToObjByFrm(FormCollection frm)
        {
            AccountBook target = null;
            bool isVerifySuccess = this.chkFormData(frm);
            if (isVerifySuccess)
            {
                int frmMoney, frmCategory;
                DateTime frmDate;
                Int32.TryParse(frm["money"], out frmMoney);
                DateTime.TryParse(frm["date"], out frmDate);
                Int32.TryParse(frm["category"], out frmCategory);
                string frmDescribe = frm["description"];

                target = new AccountBook();
                target.Id = Guid.NewGuid();
                target.Amounttt = frmMoney;
                target.Dateee = frmDate;
                target.Categoryyy = frmCategory;
                target.Remarkkk = frmDescribe;
            }
            return target;
        }
        /// <summary>
        /// 透過FormColletcion接資料的輸入驗證
        /// </summary>
        /// <param name="frm">表單資料</param>
        /// <returns></returns>
        public bool chkFormData(FormCollection frm)
        {
            //TODO:金額僅允許正整數
            //TODO:日期不得大於今天
            //TODO:備註最多100字元，必填
            bool isVerifySuccess = true;
            int frmMoney, frmCategory;
            DateTime frmDate;
            if (!Int32.TryParse(frm["money"], out frmMoney)) { isVerifySuccess = false; }
            if (!DateTime.TryParse(frm["date"], out frmDate)) { isVerifySuccess = false; }
            if (!Int32.TryParse(frm["category"], out frmCategory)) { isVerifySuccess = false; }
            if (String.IsNullOrEmpty(frm["description"])) { isVerifySuccess = false; }
            return isVerifySuccess;
        }

        /// <summary>
        /// 取得一筆紀錄
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AccountBook Find(Guid id)
        {
            return _acctRep.GetSingle(a => a.Id == id);
        }

        /// <summary>
        /// 新增一筆紀錄
        /// </summary>
        /// <param name="entity"></param>
        public void Add(AccountBook entity)
        {
            entity.Dateee = DateTime.Now;
            _acctRep.Create(entity);
        }

        /// <summary>
        /// 修改一筆紀錄
        /// </summary>
        /// <param name="pageData"></param>
        /// <param name="entity"></param>
        public void Edit(AccountBook pageData,AccountBook entity)
        {
            entity.Amounttt = pageData.Amounttt;
            entity.Categoryyy = pageData.Categoryyy;
            entity.Dateee = DateTime.Now;
            entity.Remarkkk = pageData.Remarkkk;

        }

        /// <summary>
        /// 刪除一筆紀錄
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(AccountBook entity)
        {
            _acctRep.Remove(entity);
        }

        /// <summary>
        /// 資料確認變更
        /// </summary>
        public void Save()
        {
            _acctRep.Commit();
        }
    }
}