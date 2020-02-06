using System;

namespace CalendarioDeEventos
{
    public class TextFormater : ITextFormater
    {
        protected ITimeChecker _timeChecker;

        public TextFormater(ITimeChecker timeChecker)
        {
            _timeChecker = timeChecker;
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
            string response = "";

                TimeSpan timeSpan = timeCheckerResponse.TimePast;
               
                int timeValue;
                string timeMagnitude;

            if(timeSpan.TotalDays > 30)
            {
                timeValue = (int)timeSpan.TotalDays / 30;
                timeMagnitude = "meses";
            }
            else if(timeSpan.TotalHours >= 24)
            {
                timeValue = (int)timeSpan.TotalHours / 24;
                timeMagnitude = "días";
            }
            else if(timeSpan.TotalMinutes > 60)
            {
                timeValue = (int)timeSpan.TotalMinutes / 60;
                timeMagnitude = "horas";
            }
            else
            {
                timeValue = (int)timeSpan.TotalMinutes;
                timeMagnitude = "minutos";
            }
            string template = "";
            if (timeCheckerResponse.Past)
            {         
                template = "{0} ocurrió hace {1} {2}";

            }
            else
            {
                template = "{0} ocurrirá dentro de {1} {2}";
            }
            response = string.Format(template, evento, timeValue, timeMagnitude);
            return response;
        }
    }
}
