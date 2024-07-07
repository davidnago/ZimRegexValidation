using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZimRegexLib.Annotations
{
    public class DateRangeAttribute : ValidationAttribute
    {
            private const string DefaultErrorMessage = "The {0} field is not a valid date.";
            public bool ValidatePast { get; set; }
            public bool ValidateFuture { get; set; }
            public DateTime MinDate { get; set; } = DateTime.MinValue;
            public DateTime MaxDate { get; set; } = DateTime.MaxValue;

            public DateRangeAttribute() : base(DefaultErrorMessage) { }


            public DateRangeAttribute(bool validatePast = false, bool validateFuture = false, string minDate = null, string maxDate = null) : base(DefaultErrorMessage)
            {
                ValidatePast = validatePast;
                ValidateFuture = validateFuture;

                if (!string.IsNullOrEmpty(minDate))
                {
                    MinDate = DateTime.Parse(minDate);
                }

                if (!string.IsNullOrEmpty(maxDate))
                {
                    MaxDate = DateTime.Parse(maxDate);
                }
            }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value == null)
                {
                    return ValidationResult.Success;
                }

                if (value is DateTime dateValue)
                {
                    if (ValidatePast && dateValue > DateTime.Now)
                    {
                        return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, validationContext.DisplayName));
                    }

                    if (ValidateFuture && dateValue < DateTime.Now)
                    {
                        return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, validationContext.DisplayName));
                    }

                    if (dateValue < MinDate || dateValue > MaxDate)
                    {
                        return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, validationContext.DisplayName));
                    }

                    return ValidationResult.Success;
                }

                return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, validationContext.DisplayName));
            }
        }
    }



