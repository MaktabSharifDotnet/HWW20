using System.Globalization;

namespace App.Domain.Core.Utils 
{
    public static class DateExtensions
    {
       
        public static DateTime ToGregorianDate(this string persianDate)
        {
            if (string.IsNullOrWhiteSpace(persianDate))
                return DateTime.Now;

            var pc = new PersianCalendar();
            var parts = persianDate.Split('/'); 

            int year = int.Parse(parts[0]);
            int month = int.Parse(parts[1]);
            int day = int.Parse(parts[2]);

            return pc.ToDateTime(year, month, day, 0, 0, 0, 0);
        }

       
        public static int GetCarAge(this int persianProductionYear)
        {
            var pc = new PersianCalendar();
            var today = DateTime.Now;

            
            int currentPersianYear = pc.GetYear(today);

            
            return currentPersianYear - persianProductionYear;
        }
    }
}