using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZimRegexLib.Extensions;

namespace ZimRegexLib.Annotations
{
    public class PasswordAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "The {0} field does not meet minimum password requirements (minimum of 8 characters, at least 1 special character, 1 capital letter, 1 numeric character)";

        public PasswordAttribute() : base(DefaultErrorMessage) { }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            if (value is string stringValue && stringValue.IsValidPassword())
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
         

    }
}
