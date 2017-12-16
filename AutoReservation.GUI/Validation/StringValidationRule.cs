using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AutoReservation.GUI.Validation
{
    public class StringValidationRule : ValidationRule
    {
        public StringValidationRule()
        {
        }

        public int Min { get; set; }
        public int Max { get; set; }
        public bool CanBeEmpty { get; set; }
        public bool Number { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str = "";

            if (!(value is string))
            {
                return new ValidationResult(false, "Value is not a string");
            }
            str = (string)value;

            if (Number && !Regex.IsMatch(str, @"[0-9]+$"))
            {
                return new ValidationResult(false, $"String needs to be only numbers");
            }
            else if (!CanBeEmpty && str.Length == 0)
            {
                return new ValidationResult(false, "Value can't be empty");
            }
            else if(str.Length < Min || Max > 0 && str.Length > Max)
            {
                return new ValidationResult(false, $"String length has to be in the range: {Min} - {Max}");
            }

            return new ValidationResult(true, null);
        }
    }
}
