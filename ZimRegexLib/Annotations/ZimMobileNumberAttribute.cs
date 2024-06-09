﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ZimRegexLib.Extensions;

namespace ZimRegexLib.Annotations
{
    public class ZimMobileNumberAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "The {0} field is not a valid Zimbabwean mobile number.";

        public ZimMobileNumberAttribute() : base(DefaultErrorMessage) { }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
          if (value == null)
            {
              return ValidationResult.Success;
          }
          if (value is string stringValue && stringValue.IsValidZimbabweanMobileNumber() )
            {
              return ValidationResult.Success;
          }
          return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

    }
}
