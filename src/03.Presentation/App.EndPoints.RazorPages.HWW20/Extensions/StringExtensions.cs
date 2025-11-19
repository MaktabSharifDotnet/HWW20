using System.Text.RegularExpressions;

namespace App.EndPoints.RazorPages.HWW20.Pages.Extensions
{
    public static class StringExtensions
    {
        
        public static bool IsValidMobileNumber(this string phoneNumber)
        {
           
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

           
            const string pattern = @"^09\d{9}$";

            return Regex.IsMatch(phoneNumber, pattern);
        }
    }
}