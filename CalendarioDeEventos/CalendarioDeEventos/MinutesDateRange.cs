using System;

namespace CalendarioDeEventos
{
    public class MinutesDateRange : IDateRange
    {
        public string Range => DateRanges.Minutes;

        public bool Validate(TimeSpan timeSpan)
        {
            if(timeSpan.Minutes <= 60)
            {
                return true;
            }
            return false;
        }
    }
}
