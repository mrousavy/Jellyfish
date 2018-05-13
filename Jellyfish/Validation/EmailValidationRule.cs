using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Jellyfish.Validation
{
    /// <inheritdoc />
    /// <summary>
    ///     Validate a given string to be a valid email using regular expressions
    /// </summary>
    public class EmailValidationRule : ValidationRule
    {
        // See: https://stackoverflow.com/a/201378
        private const string EmailRegex =
            "(?:[a-z0-9!#$%&\'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&\'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])";

        private const string InvalidMessage = "Not a valid email address!";

        private const string InvalidTypeMessage = "Value is not a valid string!";

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string email)
                return new ValidationResult(Regex.IsMatch(email, EmailRegex), InvalidMessage);
            return new ValidationResult(false, InvalidTypeMessage);
        }
    }
}