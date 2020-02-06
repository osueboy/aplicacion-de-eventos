using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarioDeEventos
{
    public class TimeCheckerResponse
    {
        public bool Past { get; set; }
        public TimeSpan TimePast {get; set;}
    }
}
