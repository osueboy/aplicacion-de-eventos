using System;

namespace CalendarioDeEventos
{
    public class ConsolePrinter : IPrinter
    {
        protected ITextFormater _textFormater;

        public ConsolePrinter(ITextFormater textFormater)
        {
            _textFormater = textFormater;
        }

        public void PrintText(string text)
        {
            Console.WriteLine(_textFormater.FormatText(text));
        }
    }
}
