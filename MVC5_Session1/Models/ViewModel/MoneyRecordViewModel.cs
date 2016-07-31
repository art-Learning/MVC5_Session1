using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5_Session1.Models
{
    /// <summary>
    /// 流水帳紀錄
    /// </summary>
    public class MoneyRecordViewModel
    {
        /// <summary>
        /// 類別
        /// </summary>
        public MoneyType moneyType { get; set; }
        /// <summary>
        /// 消費日期
        /// </summary>
        public DateTime createDts { get; set; }
        /// <summary>
        /// 金額
        /// </summary>
        public int amount { get; set; }
    }
}