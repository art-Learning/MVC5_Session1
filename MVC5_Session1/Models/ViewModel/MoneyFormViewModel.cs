using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5_Session1.Models.ViewModel
{
    /// <summary>
    /// 記帳本表單ViewModel
    /// </summary>
    public partial class MoneyFormViewModel
    {
        /// <summary>
        /// 類別
        /// </summary>
        public int category { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime date { get; set; }
        /// <summary>
        /// 金額
        /// </summary>
        public int money { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string description { get; set; }
    }
}