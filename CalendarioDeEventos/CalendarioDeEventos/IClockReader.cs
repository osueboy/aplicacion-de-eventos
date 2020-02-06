using System;

namespace CalendarioDeEventos
{
    public interface IClockReader
    {
        DateTime CurrentTime();
    }
}