using System;

namespace CalendarioDeEventos
{
    public class DaysTimeValueProvider : ITimeValueProvider
    {
        public string Range => DateRanges.Days;

        public int GetTimeValue(TimeSpan timeSpan)
        {
            return (int)timeSpan.TotalDays;
        }
    }
}
