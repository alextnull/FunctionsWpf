using System.Globalization;
using System.Windows.Controls;

namespace FunctionsWpf.Infrastructure.ValidationRules
{
    internal class NumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int number;
            bool isValid = int.TryParse(value as string, out number);
            return new ValidationResult(isValid, "Не допустимое значение");
        }
    }
}
