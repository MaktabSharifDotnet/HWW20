using System.Text.RegularExpressions;

namespace App.EndPoints.RazorPages.HWW20.Pages.Extensions
{
    public static class LicensePlateExtensions
    {
        public static bool IsValidIranianLicensePlate(this string licensePlate)
        {
          
            if (string.IsNullOrWhiteSpace(licensePlate))
                return false;

        
            licensePlate = licensePlate.Replace(" ", "");

         
            const string pattern = @"^\d{2}[آ-ی]\d{3}\d{2}$";

           
            if (!Regex.IsMatch(licensePlate, pattern))
                return false;

        
            char letter = licensePlate[2]; 
            string allowedLetters = "بجطیدسصقلمنوه1234567890"; 
 
            return true;
        }
    }
}