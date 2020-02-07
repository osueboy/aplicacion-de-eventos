using Microsoft.Extensions.DependencyInjection;

namespace CalendarioDeEventos
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped(typeof(IClockReader), typeof(Clock))
                .AddScoped(typeof(ITimeChecker), typeof(TimeChecker))
                .AddScoped(typeof(IRangeManager), typeof(RangeManager))
                .AddScoped(typeof(ITimeValueManager), typeof(DefaultTimeValueManager))
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
