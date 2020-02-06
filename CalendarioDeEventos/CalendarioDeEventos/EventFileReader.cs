using System;
using System.Collections.Generic;
using System.IO;

namespace CalendarioDeEventos
{
    public class EventFileReader : ITextFileReader
    {

        public EventFileReader()
        {
        }

        public List<string> ReadLines(string path)
        {
            List<string> lines = new List<string>();
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return lines;
        }
    }
}
