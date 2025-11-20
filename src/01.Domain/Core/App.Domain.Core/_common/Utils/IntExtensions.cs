using System.Globalization;

namespace App.Domain.Core._common.Utils
{
    public static class IntExtensions
    {
        public static bool IsCarModelTooOld(this int modelYear, int maxAge = 5)
        {
            
            var pc = new PersianCalendar();

        
            int currentPersianYear = pc.GetYear(DateTime.Now);

          
            int carAge = currentPersianYear - modelYear;

           
            return carAge > maxAge;
        }
        public static int ToGregorianYear(this int shamsiYear)
        {
       
            var pc = new PersianCalendar();

            
            DateTime gregorianDate = pc.ToDateTime(shamsiYear, 1, 1, 0, 0, 0, 0);

            return gregorianDate.Year;
        }
    }
}