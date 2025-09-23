using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_seven.TextFileProcessor
{
    public class FileProcessor
    {
        public static void ProcessFile(string folderName, string fileName, string wordToSearch)
        {
            string filePath = Path.Combine(folderName, fileName);

            // checking the folder and file
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found!");
                return;
            }

            string[] lines= File.ReadAllLines(filePath);

            int linesCount = lines.Length;
            int wordsCount = 0;
            int charactersCount = 0;
            var linesWithWord = new List<int>();

            for (int i = 0; i < lines.Length; i++)
            { 
                string line = lines[i];
                charactersCount += line.Length;

                string[] words = line.Split(new char[] { ' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
                wordsCount += words.Length;

                if (line.IndexOf(wordToSearch, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    linesWithWord.Add(i + 1);
                }
            }

            Console.WriteLine($"Lines : {linesCount}");
            Console.WriteLine($"Words : {wordsCount}");
            Console.WriteLine($"Characters : {charactersCount}");

            if (linesWithWord.Any())
            {
                Console.WriteLine($"Word \"{wordToSearch}\" found at lines: {string.Join(", ", linesWithWord)}");
            }
            else
            {
                Console.WriteLine($"Word \"{wordToSearch}\" not found in any line.");
            }

        }
    }
}
