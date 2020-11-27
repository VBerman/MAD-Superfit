using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MAD_Superfit
{
    public static class MyValidator
    {
        public static bool Validation(this object thisObject, out string result)
        {
            var context = new ValidationContext(thisObject);
            var validationResults = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(thisObject, context, validationResults, true);
            var strB = new StringBuilder();
            foreach (var item in validationResults)
            {
                strB.AppendLine(item.ErrorMessage);
            }

            result = strB.ToString();

            return valid;
        }
    }
}
