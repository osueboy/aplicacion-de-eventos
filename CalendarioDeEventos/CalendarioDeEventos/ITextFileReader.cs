using System.Collections.Generic;

namespace CalendarioDeEventos
{
    public interface ITextFileReader
    {
        List<string> ReadLines(string path);
    }
}
