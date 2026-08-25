using System.Globalization;

namespace Aspdotnetkar.Models
{
    public static class ShamsiDatetime
    {
        public static string toshamsi(DateTime date)
        {
            var pc = new PersianCalendar();
            return $"{pc.GetDayOfMonth(date)}/{pc.GetMonth(date)}/{pc.GetYear(date)}";
        }
    }
}
