using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace CheckLogsApatch
{
    public class ScanFile
    {
        public List<Log> logs = new List<Log>();

        public static string defaultPath = @"c:\xampp\apache\logs\access.log";

        public string path { get; set; } = string.Empty; 

        public ScanFile()
        {
        }

        public bool checkFileByDefaultPath()
        {
            if (!File.Exists(defaultPath))
            {
                Console.WriteLine("[checkFileByDefaultPath]: File DOES NOT exists by path " + defaultPath);
                return false;
            }
            path = defaultPath;
            Console.WriteLine("[checkFileByDefaultPath]: File exists by path " + defaultPath);
            return true;
        }

        public void readLogsFile()
        {
            logs.Clear();
            var file = new StreamReader(path);
            string line = string.Empty;
            while ((line = file.ReadLine()) != null)
            {
                parseLogLine(line);
                // Console.WriteLine("[checkFileByDefaultPath]: Line: " + line);
            }
        }

        public void parseLogLine(string logLine)
        {
            if (Log.testLog(logLine))
            {
                Log log = new Log(logLine);
                logs.Add(log);
                Console.WriteLine($"{log}");
            } else
            {
                Console.WriteLine($"[parseLogLine] INVALID FORMAT {logLine}");
            }
        }
    }
}
