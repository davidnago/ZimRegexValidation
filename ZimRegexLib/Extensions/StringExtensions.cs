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
        #region Moboile Number Extensions
        private static readonly Dictionary<string, string> MobileNumberPatterns = new Dictionary<string, string>
        {
            { "Econet", @"^(\+263|0)(77[2-9]|78[2-9])\d{6}$" },
            { "NetOne", @"^(\+263|0)71[2-9]\d{6}$" },
            { "Telecel", @"^(\+263|0)73[2-9]\d{6}$" }
        };
        public static bool IsZimbabweanMobileNumber(this string input)
        {
            return MobileNumberPatterns.Values.Any(pattern => System.Text.RegularExpressions.Regex.IsMatch(input, pattern));
        }

        public static bool IsEconetNumber(this string input)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(input, MobileNumberPatterns["Econet"]);
        }
        
        public static bool IsNetOneNumber(this string input)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(input, MobileNumberPatterns["NetOne"]);
        }

        public static bool IsTelecelNumber(this string input)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(input, MobileNumberPatterns["Telecel"]);
        }
        #endregion


        public static bool IsValidZimPassportNumber(this string input)
        {
            return Regex.IsMatch(input, @"^[A-Z]{2}\d{6}$");
        }

        public static bool IsValidZimIdNumber(this string input)
        {
            return Regex.IsMatch(input, @"^\d{2}-\d{7}[A-Z]{2}$");
        }

    }

}
