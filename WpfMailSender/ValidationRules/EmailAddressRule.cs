using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace WpfMailSender.ValidationRules
{
    internal class EmailAddressRule : ValidationRule
    {
        string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!(value is string address)) return new ValidationResult(false, "Некорректные данные");
            if (!Regex.IsMatch(address, pattern))
                return new ValidationResult(false, "Некорректный Email адрес");
            return ValidationResult.ValidResult;
        }
    }
}
