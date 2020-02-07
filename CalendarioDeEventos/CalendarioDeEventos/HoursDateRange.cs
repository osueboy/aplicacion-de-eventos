using System;

namespace CalendarioDeEventos
{
    public class HoursDateRange : IDateRange
    {
        public string Range => DateRanges.Hours;

        public bool Validate(TimeSpan timeSpan)
        {
            if (timeSpan.TotalMinutes >= 60)
            {
                return true;
            }
            return false;
        }
    }
}
