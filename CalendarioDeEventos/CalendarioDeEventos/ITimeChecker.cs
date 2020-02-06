using System;

namespace CalendarioDeEventos
{
    public interface ITimeChecker
    {
        TimeCheckerResponse CheckTime(DateTime dateToVerify);
    }
}
