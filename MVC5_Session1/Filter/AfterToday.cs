using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5_Session1.Filter
{
    public sealed class  AfterToday : ValidationAttribute,IClientValidatable
    {
        public string Input { get; set; }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ValidationType = "aftertoday",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName())
            };
            rule.ValidationParameters["input"] = Input;
            yield return rule;
        }
        public AfterToday()
        {

        }
        public AfterToday(string input)
        {
            this.Input = input;
        }
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var usrDate = value as DateTime?;
            if (usrDate.HasValue)
            {
                if (usrDate.Value.Date > DateTime.Today)
                    return false;
            }

            return true;
        }
    }
}