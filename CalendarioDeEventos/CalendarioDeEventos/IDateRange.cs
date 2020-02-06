using System;

namespace CalendarioDeEventos
{
    public interface IDateRange
    {
        string Range { get; }
        bool Validate(TimeSpan timeSpan);
    }
}
