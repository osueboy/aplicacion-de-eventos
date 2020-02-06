using System;

namespace CalendarioDeEventos
{
    public interface IRangeManager
    {

        string GetRange(TimeSpan timeSpan);
    }
}
