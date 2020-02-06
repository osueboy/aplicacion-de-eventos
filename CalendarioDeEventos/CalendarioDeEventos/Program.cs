using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;

namespace CalendarioDeEventos
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddScoped(typeof(IClockReader), typeof(Clock))
                .AddScoped(typeof(ITimeChecker), typeof(TimeChecker))
                .AddScoped(typeof(ITextFormater), typeof(TextFormater))
                .AddScoped(typeof(IPrinter), typeof(ConsolePrinter))
                .AddScoped(typeof(ITextFileReader), typeof(EventFileReader))
                .AddScoped(typeof(IEventVerificationService), typeof(EventVerificationService))
                .BuildServiceProvider();

            IEventVerificationService eventVerificationService = serviceProvider.GetRequiredService<IEventVerificationService>();
            string path = @"C:\Temp\eventos.txt";
            eventVerificationService.GetAllEvents(path);

        }
    }
}
