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
        public List<Log> allLogs = new List<Log>();

        public List<Log> filteredLogs = new List<Log>();

        public FilterProps filter = new FilterProps();

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
            allLogs.Clear();
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
                allLogs.Add(log);
                Console.WriteLine($"{log}");
            } else
            {
                Console.WriteLine($"[parseLogLine] INVALID FORMAT {logLine}");
            }
        }

        public void filterLogs()
        {
            filteredLogs.Clear();

            foreach(var log in allLogs)
            {
                if (log.testLogFilter(filter))
                {
                    filteredLogs.Add(log);
                }
            }
        }
    }
}
