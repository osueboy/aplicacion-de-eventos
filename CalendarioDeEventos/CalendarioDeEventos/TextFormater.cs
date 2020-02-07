using System;

namespace CalendarioDeEventos
{
    public class TextFormater : ITextFormater
    {

        public const string PastTemplate = "{0} ocurrió hace {1} {2}";
        public const string FutureTemplate = "{0} ocurrirá dentro de {1} {2}";

        protected ITimeChecker _timeChecker;
        protected ITimeValueManager _timeValueManager;

        public TextFormater(ITimeChecker timeChecker, ITimeValueManager timeValueManager)
        {
            _timeChecker = timeChecker;
            _timeValueManager = timeValueManager;
        }

        public string FormatText(string text)
        {
            string evento;
            string tiempo;

            string[] split = text.Split(",");
            evento = split[0];
            tiempo = split[1].Trim();
            DateTime fecha = DateParser.ParseDate(tiempo);
            TimeCheckerResponse timeCheckerResponse = _timeChecker.CheckTime(fecha);
            TimeSpan timeSpan = timeCheckerResponse.TimePast;      
            TimeValueResponse timeValueResponse = _timeValueManager.GetTimeValue(timeSpan);
            string template = timeCheckerResponse.Past ? PastTemplate : FutureTemplate;
            string response = string.Format(template, evento, timeValueResponse.Value, timeValueResponse.DateRange);
            return response;
        }
    }
}
