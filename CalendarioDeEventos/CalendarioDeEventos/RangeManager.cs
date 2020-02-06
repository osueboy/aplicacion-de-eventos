using System;
using System.Collections.Generic;

namespace CalendarioDeEventos
{
    public class RangeManager : IRangeManager
    {

        private List<IDateRange> _dateRanges = new List<IDateRange>();

        public RangeManager()
        {
            _dateRanges.Add(new MonthDateRange());
            _dateRanges.Add(new DaysDateRange());
            _dateRanges.Add(new HoursDateRange());
            _dateRanges.Add(new MinutesDateRange());
        }
        public string GetRange(TimeSpan timeSpan)
        {

            foreach(IDateRange dateRange in _dateRanges)
            {
                if (dateRange.Validate(timeSpan))
                {
                    return dateRange.Range;
                }
            }
            return DateRanges.Minutes;
        }
    }
}
