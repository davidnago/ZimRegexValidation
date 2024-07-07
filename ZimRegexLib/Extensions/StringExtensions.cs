using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZimRegexLib.Extensions
{
    public static class StringExtensions
    {
        #region Mobile and Land Number Extensions
        private static readonly Dictionary<MobileServiceProvider, string> MobileNumberPatterns = new Dictionary<MobileServiceProvider, string>
        {
            { MobileServiceProvider.Econet, @"^(\+263|0)(77[1-9]\d{6}|78[2-7]\d{6})$" },
            { MobileServiceProvider.NetOne, @"^(\+263|0)71[2-9]\d{6}$" },
            { MobileServiceProvider.Telecel, @"^(\+263|0)73[2-9]\d{6}$" }
        };
        public static bool IsValidZimbabweanMobileNumber(this string input)
        {
            input = input.Trim();
            return MobileNumberPatterns.Values.Any(pattern => System.Text.RegularExpressions.Regex.IsMatch(input, pattern));
        }

        public static bool IsValidEconetNumber(this string input)
        {
            input = input.Trim();
            return System.Text.RegularExpressions.Regex.IsMatch(input, MobileNumberPatterns[MobileServiceProvider.Econet]);
        }
        
        public static bool IsValidNetOneNumber(this string input)
        {
            input = input.Trim();
            return System.Text.RegularExpressions.Regex.IsMatch(input, MobileNumberPatterns[MobileServiceProvider.NetOne]);
        }

        public static bool IsValidTelecelNumber(this string input)
        {
            input = input.Trim();
            return System.Text.RegularExpressions.Regex.IsMatch(input, MobileNumberPatterns[MobileServiceProvider.Telecel]);
        }

        public static bool IsValidZimLandline(this string input)
        {
            input = input.Trim();
            return Regex.IsMatch(input, @"^(\+263|0)24\d{7}$");
        }

        #endregion


        public static bool IsValidZimPassportNumber(this string input)
        {
            input = input.Trim();
            return Regex.IsMatch(input, @"^[A-Z]{2}\d{6}$");
        }

        public static bool IsValidZimIdNumber(this string input)
        {
            input = input.Trim();
            return Regex.IsMatch(input, @"^\d{2}-\d{7}[A-Z]{2}$");
        }

        public static bool IsValidZimNumberPlate(this string input)
        {
            input = input.Trim();
            return Regex.IsMatch(input, @"^[A-Z]{3}\s\d{4}$");
        }

        public static bool IsValidZimDriversLicence(this string input)
        {
            input = input.Trim();
            return Regex.IsMatch(input, @"^[A-Z]{2}\d{6}$");
        }

        public static bool IsValidUrl(this string input)
        {
            input = input.Trim();
            return Regex.IsMatch(input, @"^(http|https)://[^\s/$.?#].[^\s]*$");
        }

        //Check if password is valid (minimum of 8 characters, at least 1 special character, 1 capital letter, 1 numeric character)
        public static bool IsValidPassword(this string input)
        {
    
            return Regex.IsMatch(input, @"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+])[A-Za-z\d!@#$%^&*()_+]{8,}$");
        }



        #region Format Extensions
        public static string? FormatNumber(this string input, MobileNumFormatType formatType)
        {
            input = input.Trim();
            if (!input.IsValidZimbabweanMobileNumber())
                return null;

            switch (formatType)
            {
                case MobileNumFormatType.Regular:
                    return input.StartsWith("+263") ? "0" + input.Substring(4) : input;
                case MobileNumFormatType.CountryCode:
                    return input.StartsWith("+") ? input.Substring(1) : "263" + input.Substring(1);
                case MobileNumFormatType.CountryCodePlus:
                    return input.StartsWith("+") ? input : "+263" + input.Substring(1);
                default:
                    return input;
            }
        }

        public static string FormatID(this string input, IdFormatType formatType)
        {
            input = input.Trim();
            if (!input.IsValidZimIdNumber())
                return input;

            return formatType switch
            {
                IdFormatType.Standard => $"{input.Substring(0, 2)}-{input.Substring(2, 7)} {input.Substring(9, 1).ToUpper()} {input.Substring(10).ToUpper()}",
                _ => input
            };
        }
        #endregion
    }

}
