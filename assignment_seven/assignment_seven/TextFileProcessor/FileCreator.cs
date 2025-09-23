using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_seven.TextFileProcessor
{
    public class FileCreator
    {
        //create folder name TextFileProcesser and file name sample.text
        public static void CreateFile(string folderName, string fileName)
        {
            string filePath = Path.Combine(folderName, fileName);

            if (!Directory.Exists(folderName)) 
            {
                Directory.CreateDirectory(folderName);
                Console.WriteLine($"Folder created : {folderName}");
            }

            string[] content = new string[]
                {
                    "There are 20 members in intern.",
                    "intern is for three months"
                };
            File.WriteAllLines(filePath, content);
            Console.WriteLine($" file Name : {fileName} create sucessfully at {folderName} folder.");
        }
    }
}
