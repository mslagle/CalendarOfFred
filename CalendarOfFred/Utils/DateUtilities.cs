namespace CalendarOfFred.Utils
{
    public static class DateUtilities
    {
        public static DateOnly GetNthDayOfNthWeek(this DateOnly dateTime, DayOfWeek dayofWeek, int weekNumber)
        {
            //get first day of the given date
            DateTime dtFirst = new DateTime(dateTime.Year, dateTime.Month, 1);

            //get first DayOfWeek of the month
            DateTime dtRet = dtFirst.AddDays(((int)dayofWeek + 7 - (int)dtFirst.DayOfWeek) % 7);

            //get which week
            dtRet = dtRet.AddDays((weekNumber - 1) * 7);

            //if day is past end of month then adjust backwards a week
            if (dtRet >= dtFirst.AddMonths(1))
            {
                dtRet = dtRet.AddDays(-7);
            }

            //return
            return DateOnly.FromDateTime(dtRet);
        }
    }
}
