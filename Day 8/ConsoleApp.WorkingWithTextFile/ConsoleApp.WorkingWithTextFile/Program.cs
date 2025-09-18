namespace ConsoleApp.WorkingWithTextFile;

public class Program
{
    static void Main(string[] args)
    {

        string filePath = "sample.txt";
        string logPath = "app.log.txt";
        try
        {
            string[] lines = File.ReadAllLines("sample.txt");
            Console.WriteLine("the no of lines in text file is: " + lines.Length);

            int characters = 0;
            int Words = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] words = lines[i].Split(' ');
                Words = Words + words.Length;
                characters += lines[i].Length;


            }

            Console.WriteLine("the no of words in text file is: " + Words);
            Console.WriteLine("the no of character in text file is: " + characters);

            string searchWord = "intern";
            bool found = false;
            for (int i = 0; i < lines.Length; i++)
            {
                // convert both line and word to lowercase to ignore case
                if (lines[i].ToLower().Contains(searchWord.ToLower()))
                {
                    Console.WriteLine($"Word {searchWord} found at line: " + (i + 1));
                    found = true;
                }
               
            }
            if (!found)
            {
                Logger(logPath, "Word not found in text file", "WRANING");
            }

            Logger(logPath, "Operations completed sucessfully", "SUCCESS");

        }
        catch (FileNotFoundException)
        {
            Logger(logPath, "File not Found", "ERROR");
        }catch(Exception e)
        {
            Logger(logPath, e.Message, "ERROR");
        }
        
        
    }

    static void Logger(string logFile, string message, string logType)
    {
        string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{logType}] {message}{Environment.NewLine}";
        File.AppendAllText(logFile, logEntry);
    }
}
