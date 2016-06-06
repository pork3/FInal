using System;
using System.Collections.Generic;
using System.IO;

namespace L2Ch3.ConsoleApp
{
    /// <summary>
    /// Contains methods for parsing csd text files
    /// </summary>
    public class TextParser
    {
        string delimiter;
        int numFields;

        public TextParser(string columnDelimiter, int numberOfFields)
        {
            delimiter = columnDelimiter;
            numFields = numberOfFields;
        }

        public List<string[]> ParseText(Stream stream)
        {
            List<string[]> rows = new List<string[]>();
            /* For testing
            rows.Add (new string[] {"mono", "monkey", "noun"});
            rows.Add (new string[] {"agua", "water", "noun"});
            rows.Add (new string[] {"si", "yes", "noun"});
            rows.Add (new string[] {"perro", "dog", "noun"});
            rows.Add (new string[] {"gato", "cat", "noun" });
            rows.Add (new string[] {"sustantivo", "noun", "noun" });
            */

            string[] delim = new string[1];
            delim[0] = delimiter;

            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    rows.Add(reader.ReadLine().Split(delim, numFields, StringSplitOptions.None));
                }
            }

            return rows;
        }

        internal static object ParseText(string[] tidePredictions)
        {
            throw new NotImplementedException();
        }
    }
}

