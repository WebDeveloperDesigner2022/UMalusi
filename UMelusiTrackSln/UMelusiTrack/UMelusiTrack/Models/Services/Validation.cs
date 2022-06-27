using Microsoft.Data.Edm.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace UMelusiTrack.Models.Services
{
    /*internal class Validation : ValidationRule
    {
        public override Validation Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string _strInt = value.ToString();
            int _int = -1;
            if (!Int32.TryParse(_strInt, out _int))
                return new ValidationResult(false, "Value must be an integer");
            if (_int < 0)
                return new ValidationResult(false, "Value must be positive");
            return new ValidationResult(true, null);
        }
    }*/
}
