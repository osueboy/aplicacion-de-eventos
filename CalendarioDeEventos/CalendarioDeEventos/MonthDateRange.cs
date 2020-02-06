using System;

namespace CalendarioDeEventos
{
    public class MonthDateRange : IDateRange
    {
        public string Range => DateRanges.Months;
        public bool Validate(TimeSpan timeSpan)
        {
            if (timeSpan.TotalDays > 30)
            {

                return true;
            }
            return false;
        }
    }
}
