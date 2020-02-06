using System;

namespace CalendarioDeEventos
{
    public class Clock : IClockReader
    {
        public DateTime CurrentTime()
        {
            return DateTime.Now;
        }
    }
}
