using BalanceViewer.Entities;
using System.Globalization;

namespace BalanceViewer.Converters
{
    public static class DateConverter
    {
        public static DateTime ToDateTime(this int value)
        {
            DateTime date;
            DateTime.TryParseExact(value.ToString(), "yyyyMM",
                          CultureInfo.InvariantCulture,
                          DateTimeStyles.None, out date);

            return date;
        }

        public static int DateTimeToInt(this DateTime value)
        {
            return value.Year * 100 + value.Month;
        }
    }
}
