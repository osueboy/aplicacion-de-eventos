using System;

namespace CalendarioDeEventos
{
    public class DaysDateRange : IDateRange
    {
        public string Range => DateRanges.Days;

        public bool Validate(TimeSpan timeSpan)
        {
            if (timeSpan.TotalHours >= 24)
            {
                return true;
            }
            return false;
        }
    }
}
