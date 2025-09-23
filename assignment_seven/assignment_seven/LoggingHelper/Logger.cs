using System;
using System.Collections.Generic;
using System.IO;

namespace assignment_seven.LoggingHelper
{
    public class Logger
    {
        private static string LogFilePath;
        public static void LogFolder(string folderPath, string fileName)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            LogFilePath = Path.Combine(folderPath, fileName);
        }

        public static void Log(string message, string level)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logEntry = $"[{timestamp}] [{level}] {message}";
            File.AppendAllText(LogFilePath, logEntry);
        }
    }
}
