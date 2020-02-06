using System;
using System.Collections.Generic;

namespace CalendarioDeEventos
{
    public class DefaultTimeValueManager : ITimeValueManager
    {
        protected Dictionary<string, ITimeValueProvider> _valueProviders = new Dictionary<string, ITimeValueProvider>();
        protected IRangeManager _rangeManager;

        public DefaultTimeValueManager(IRangeManager rangeManager)
        {
            _rangeManager = rangeManager;
            _valueProviders.Add(DateRanges.Minutes, new MinutesTimeValueProvider());
            _valueProviders.Add(DateRanges.Hours, new HoursTimeValueProvider());
            _valueProviders.Add(DateRanges.Days, new DaysTimeValueProvider());
            _valueProviders.Add(DateRanges.Months, new MonthTimeValueProvider());
        }


        public TimeValueResponse GetTimeValue(TimeSpan timeSpan)
        {
            string range = _rangeManager.GetRange(timeSpan);
            ITimeValueProvider valueProvider = _valueProviders.GetValueOrDefault(range);
            if(valueProvider != null)
            {
                return new TimeValueResponse()
                {
                    DateRange = range,
                    Value = valueProvider.GetTimeValue(timeSpan)
                };
            }
            throw new Exception("range not found");
        }
    }
}
