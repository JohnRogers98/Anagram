using System;
using System.Collections.Generic;
using System.IO;

namespace Anagram
{
    public class ReadFile
    {
        public List<String> ReadWordsFromFile(String path)
        {
            List<String> words = new List<String>();
            
            using (StreamReader reader = new StreamReader(path))
            {
                while(reader.EndOfStream == false)
                {
                    words.Add(reader.ReadLine());
                }
            }

            return words;
        }
    }
}
