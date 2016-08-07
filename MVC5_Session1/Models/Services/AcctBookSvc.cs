using MVC5_Session1.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
            return _acctRep.LookupAll();
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