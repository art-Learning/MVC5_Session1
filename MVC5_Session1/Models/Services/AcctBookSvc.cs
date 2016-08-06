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
    }
}