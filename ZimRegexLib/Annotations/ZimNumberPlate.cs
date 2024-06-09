using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZimRegexLib.Extensions;

namespace ZimRegexLib.Annotations
{
    public class ZimNumberPlate : ValidationAttribute
    {
        private const string DefaultErrorMessage = "The {0} field is not a valid Zimbabwean number plate.";

        public ZimNumberPlate() : base(DefaultErrorMessage) { }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            if (value is string stringValue && stringValue.IsValidZimNumberPlate())
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
        
    }
}
