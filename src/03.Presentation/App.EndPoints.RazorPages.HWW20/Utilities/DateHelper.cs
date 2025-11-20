
using System;
using System.Globalization;
namespace App.EndPoints.RazorPages.HWW20.Utilities
{
   

    public static class DateHelper
    {
        private static readonly PersianCalendar pc = new PersianCalendar();

        public static DateTime ShamsiToMiladi(string shamsi)
        {
            
            var parts = shamsi.Split('/');
            int year = int.Parse(parts[0]);
            int month = int.Parse(parts[1]);
            int day = int.Parse(parts[2]);

            return pc.ToDateTime(year, month, day, 0, 0, 0, 0);
        }

        public static string MiladiToShamsi(DateTime date)
        {
            return $"{pc.GetYear(date):0000}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00}";
        }
    }

}
