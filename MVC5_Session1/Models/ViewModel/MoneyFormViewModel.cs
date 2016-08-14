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
    public class MoneyFormViewModel
    {
        /// <summary>
        /// 類別
        /// </summary>
        [Display(Name ="類別")]
        public int category { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        [Display(Name ="日期")]
        public DateTime date { get; set; }
        /// <summary>
        /// 金額
        /// </summary>
        [Display(Name ="金額")]
        public int money { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        [Display(Name ="備註")]
        public string description { get; set; }
    }
}