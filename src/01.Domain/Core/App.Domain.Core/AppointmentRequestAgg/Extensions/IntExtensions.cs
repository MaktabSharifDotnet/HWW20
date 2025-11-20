using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppointmentRequestAgg.Extensions
{
    public static class IntExtensions
    {
        /// <summary>
        /// بررسی می‌کند که آیا اختلاف سال شمسی ورودی با سال شمسی جاری بیشتر از مقدار مشخص شده هست یا خیر
        /// </summary>
        /// <param name="shamsiYear">سال ساخت خودرو (شمسی)</param>
        /// <param name="maxAllowedAge">حداکثر عمر مجاز (پیش‌فرض ۵ سال)</param>
        public static bool IsCarOld(this int shamsiYear, int maxAllowedAge = 5)
        {
            // ۱. ساخت یک نمونه از تقویم شمسی
            PersianCalendar pc = new PersianCalendar();

            // ۲. گرفتن تاریخ امروز سیستم (که میلادی است)
            DateTime today = DateTime.Now;

            // ۳. استخراج سال شمسیِ امروز از تاریخ میلادی
            int currentShamsiYear = pc.GetYear(today);

            // ۴. محاسبه عمر خودرو
            int carAge = currentShamsiYear - shamsiYear;

            // ۵. بررسی شرط: اگر عمر ماشین بیشتر از ۵ سال بود، true برگردان
            return carAge > maxAllowedAge;
        }
    }
}
