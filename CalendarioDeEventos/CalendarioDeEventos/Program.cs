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
            List<string> eventLines;
            IClockReader clockReader = new Clock();
            ITimeChecker timeChecker = new TimeChecker(clockReader);
            TextFormater textFormater = new TextFormater(timeChecker);

            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(@"c:\Temp\eventos.txt"))
                {
                    eventFileReader = new EventFileReader(sr);
                    eventLines = eventFileReader.ReadLines();
                }

                foreach(string line in eventLines)
                {
                    Console.WriteLine(textFormater.FormatText(line));
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }




        }
    }
}
