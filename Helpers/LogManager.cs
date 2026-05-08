using System;
using System.IO;

namespace FacultyWorkloadSystem.Helpers
{
    public class LogManager
    {
        private static readonly string _logFolder =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                         "Resources", "logs");

        public static void LogError(Exception ex)
        {
            try
            {
                if (!Directory.Exists(_logFolder))
                    Directory.CreateDirectory(_logFolder);

                string logFile = Path.Combine(_logFolder,
                    $"log_{DateTime.Now:yyyy-MM-dd}.txt");

                string entry =
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR\n" +
                    $"Message : {ex.Message}\n" +
                    $"Source  : {ex.Source}\n" +
                    $"Stack   : {ex.StackTrace}\n" +
                    $"{new string('-', 60)}\n";

                File.AppendAllText(logFile, entry);
            }
            catch
            {
                // fail silently — logging should never crash the app
            }
        }

        public static void LogInfo(string message)
        {
            try
            {
                if (!Directory.Exists(_logFolder))
                    Directory.CreateDirectory(_logFolder);

                string logFile = Path.Combine(_logFolder,
                    $"log_{DateTime.Now:yyyy-MM-dd}.txt");

                string entry =
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] INFO : " +
                    $"{message}\n";

                File.AppendAllText(logFile, entry);
            }
            catch { }
        }
    }
}
