using System;

namespace CalendarioDeEventos
{
    public interface ITimeValueManager
    {
        TimeValueResponse GetTimeValue(TimeSpan timeSpan);
    }
}
