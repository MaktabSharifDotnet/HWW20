using System;
using System.Globalization;

namespace App.EndPoints.RazorPages.HWW20.Pages.Extensions
{
    public static class DateTimeExtensions
    {
    
        public static DateTime ToMiladi(this string persianDate)
        {
            if (string.IsNullOrWhiteSpace(persianDate))
                throw new ArgumentException("تاریخ نمی‌تواند خالی باشد.");

          
            var normalized = persianDate
                .Replace('۰', '0')
                .Replace('۱', '1')
                .Replace('۲', '2')
                .Replace('۳', '3')
                .Replace('۴', '4')
                .Replace('۵', '5')
                .Replace('۶', '6')
                .Replace('۷', '7')
                .Replace('۸', '8')
                .Replace('۹', '9');

            var parts = normalized.Split('/', '-', '.');

            if (parts.Length < 3)
                throw new FormatException("فرمت تاریخ شمسی معتبر نیست.");

            if (!int.TryParse(parts[0], out int year) ||
                !int.TryParse(parts[1], out int month) ||
                !int.TryParse(parts[2], out int day))
                throw new FormatException("اعداد تاریخ معتبر نیستند.");

            var pc = new PersianCalendar();
            return pc.ToDateTime(year, month, day, 0, 0, 0, 0);
        }

      
        public static string ToShamsi(this DateTime date)
        {
            if (date == default)
                return string.Empty;

            var pc = new PersianCalendar();
            int year = pc.GetYear(date);
            int month = pc.GetMonth(date);
            int day = pc.GetDayOfMonth(date);

            return $"{year:0000}/{month:00}/{day:00}";
        }
    }
}
