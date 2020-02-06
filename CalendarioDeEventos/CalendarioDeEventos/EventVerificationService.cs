using System.Collections.Generic;

namespace CalendarioDeEventos
{
    public class EventVerificationService : IEventVerificationService
    {
        private readonly ITextFileReader _textFileReader;
        private readonly IPrinter _printer;
        public EventVerificationService(ITextFileReader textFileReader, IPrinter printer)
        {
            _textFileReader = textFileReader;
            _printer = printer;
        }

        public void GetAllEvents(string path)
        {
            List<string> lines = _textFileReader.ReadLines(path);
            foreach (string line in lines)
            {
                _printer.PrintText(line);
            }
        }
    }
}
