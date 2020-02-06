using System;

namespace CalendarioDeEventos
{
    public interface ITimeValueProvider
    {
        string Range { get; }
        int GetTimeValue(TimeSpan timeSpan);
    }
}
