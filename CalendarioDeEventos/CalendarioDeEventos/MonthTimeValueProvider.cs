using System;

namespace CalendarioDeEventos
{
    public class MonthTimeValueProvider : ITimeValueProvider
    {
        public string Range => DateRanges.Months;

        public int GetTimeValue(TimeSpan timeSpan)
        {
            return (int)timeSpan.TotalDays / 30;
        }
    }
}
