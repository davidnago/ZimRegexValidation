using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZimRegexLib.Extensions;

namespace ZimRegexLib.Annotations
{
    public class ZimDriverLicenseAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "The {0} field is not a valid Zimbabwean driver's license number.";

        public ZimDriverLicenseAttribute() : base(DefaultErrorMessage) { }
        public ZimDriverLicenseAttribute(string errorMessage) : base(errorMessage) { }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            if (value is string stringValue && stringValue.IsValidZimDriversLicence())
            {
                return ValidationResult.Success;
            }
            var errorMessage = string.IsNullOrEmpty(ErrorMessage) ? DefaultErrorMessage : ErrorMessage;
            return new ValidationResult(string.Format(errorMessage, validationContext.DisplayName));
        }
    }
}
