using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5_Session1.Models.ViewModel
{
    [MetadataType(typeof(MoneyFormMetadata))]
    public partial class MoneyFormViewModel
    {
        private class MoneyFormMetadata
        {
            //RULE01:所有欄位必填
            //RULE02:金額，僅允許正整數
            //RULE03:日期，不可大於今天 (允許小於等於)
            //RULE04:備註，最多100字元

            [Display(Name = "類別")]
            [Required(ErrorMessage = "請選擇{0}")]
            public int category { get; set; }

            [Display(Name = "日期")]
            [Required(ErrorMessage = "請輸入{0}")]
            public DateTime date { get; set; }

            [Display(Name = "金額")]
            [Required(ErrorMessage = "請輸入{0}")]
            [Range(1, int.MaxValue, ErrorMessage = "{0}僅允許輸入正整數")]
            public int money { get; set; }

            [Display(Name = "備註")]
            [Required(ErrorMessage = "請輸入{0}")]
            [StringLength(100, MinimumLength = 0, ErrorMessage = "{0}最多只可以輸入100字元")]
            public string description { get; set; }
        }
    }
}