using System;

namespace CalendarioDeEventos
{
    public class TextFormater : ITextFormater
    {
        protected ITimeChecker _timeChecker;
        protected ITimeValueManager _timeValueManager;

        public TextFormater(ITimeChecker timeChecker, ITimeValueManager timeValueManager)
        {
            _timeChecker = timeChecker;
            _timeValueManager = timeValueManager;
        }

        public string FormatText(string text)
        {
            string response = "";
            string evento;
            string tiempo;

            string[] split = text.Split(",");
            evento = split[0];
            tiempo = split[1].Trim();
            DateTime fecha = DateParser.ParseDate(tiempo);
            TimeCheckerResponse timeCheckerResponse = _timeChecker.CheckTime(fecha);
            TimeSpan timeSpan = timeCheckerResponse.TimePast;      
            TimeValueResponse timeValueResponse = _timeValueManager.GetTimeValue(timeSpan);
            string template = "";
            if (timeCheckerResponse.Past)
            {         
                template = "{0} ocurrió hace {1} {2}";
            }
            else
            {
                template = "{0} ocurrirá dentro de {1} {2}";
            }
            response = string.Format(template, evento, timeValueResponse.Value, timeValueResponse.DateRange);
            return response;
        }
    }
}
