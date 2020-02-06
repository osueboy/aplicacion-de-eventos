using System;

namespace CalendarioDeEventos
{
    public class MinutesTimeValueProvider : ITimeValueProvider
    {
        public string Range => DateRanges.Minutes;

        public int GetTimeValue(TimeSpan timeSpan)
        {
            return (int)timeSpan.TotalMinutes;
        }
    }
}
