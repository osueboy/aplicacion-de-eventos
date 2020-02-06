using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarioDeEventos
{
    public class HoursTimeValueProvider : ITimeValueProvider
    {
        public string Range => DateRanges.Hours;

        public int GetTimeValue(TimeSpan timeSpan)
        {
            return (int)timeSpan.TotalHours;
        }
    }
}
