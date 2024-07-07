using System;
using System.ComponentModel.DataAnnotations;
using ZimRegexLib.Extensions;

namespace ZimRegexLib.Annotations
{
    public  class ZimLandLineAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "The {0} field is not a valid Zimbabwean landline number.";

        public ZimLandLineAttribute() : base(DefaultErrorMessage) { }
        public ZimLandLineAttribute(string errorMessage) : base(errorMessage) { }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            if (value is string stringValue && stringValue.IsValidZimLandline())
            {
                return ValidationResult.Success;
            }
           
            var errorMessage = string.IsNullOrEmpty(ErrorMessage) ? DefaultErrorMessage : ErrorMessage;
            return new ValidationResult(string.Format(errorMessage, validationContext.DisplayName));
        }
    }
}
