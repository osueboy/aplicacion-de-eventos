using System;
using System.Collections.Generic;
using System.IO;

namespace CalendarioDeEventos
{
    class Program
    {
        static void Main(string[] args)
        {
            EventFileReader eventFileReader;
            List<string> eventLines = new List<string>();
            IClockReader clockReader = new Clock();
            ITimeChecker timeChecker = new TimeChecker(clockReader);
            ITextFormater textFormater = new TextFormater(timeChecker);
            IPrinter printer = new ConsolePrinter(textFormater);

            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(@"c:\Temp\eventos.txt"))
                {
                    eventFileReader = new EventFileReader(sr);
                    eventLines = eventFileReader.ReadLines();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            foreach (string line in eventLines)
            {
                printer.PrintText(line);
            }

        }
    }
}
