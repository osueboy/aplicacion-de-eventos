using System;

namespace CalendarioDeEventos
{
    public class TimeChecker : ITimeChecker
    {
        protected IClockReader _clockReader;
        public TimeChecker(IClockReader clockReader)
        {
            _clockReader = clockReader;
        }

        public TimeCheckerResponse CheckTime(DateTime dateToVerify)
        {
            DateTime currentTime = _clockReader.CurrentTime();
            TimeSpan timespan = new TimeSpan(0);
            bool past = false;
            if (dateToVerify < currentTime)
            {
                past = true;
            }

            if (past)
            {
                timespan = currentTime - dateToVerify;
            }
            else
            {
                timespan = dateToVerify - currentTime;
            }

            return new TimeCheckerResponse()
            {
                Past = past,
                TimePast = timespan
            };
        }
    }
}
