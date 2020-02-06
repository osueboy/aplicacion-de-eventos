using System.Collections.Generic;
using System.IO;

namespace CalendarioDeEventos
{
    public class EventFileReader
    {
        protected readonly StreamReader _streamReader;
        public EventFileReader(StreamReader streamReader)
        {
            _streamReader = streamReader;
        }

        public List<string> ReadLines()
        {
            List<string> lines = new List<string>();
            string line;
            while ((line = _streamReader.ReadLine()) != null)
            {
                lines.Add(line);
            }
            return lines;
        }
    }
}
