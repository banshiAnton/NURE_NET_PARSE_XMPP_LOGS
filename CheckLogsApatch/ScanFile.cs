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

        public static int accessErrorTime = 10; // 1 min

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
            Log prev = null;
            allLogs.Clear();
            var file = new StreamReader(path);
            string line = string.Empty;
            while ((line = file.ReadLine()) != null)
            {
                Log next = parseLogLine(line);
                if (next == null)
                {
                    continue;
                }
                checkAccessError(prev, next);
                prev = next;
                // Console.WriteLine("[checkFileByDefaultPath]: Line: " + line);
            }
        }

        public Log parseLogLine(string logLine)
        {
            if (Log.testLog(logLine))
            {
                Log log = new Log(logLine);
                allLogs.Add(log);
                Console.WriteLine($"{log}");
                return log;
            } else
            {
                Console.WriteLine($"[parseLogLine] INVALID FORMAT {logLine}");
                return null;
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

        public void checkAccessError(Log prev, Log next)
        {
            if (prev == null || next == null)
            {
                return;
            }

            if ((prev.ip == next.ip) && (prev.path == next.path))
            {
                double dateDiff = (next.date - prev.date).TotalSeconds;

                if (dateDiff <= accessErrorTime)
                {
                    prev.accessError = true;
                    next.accessError = true;
                }
            }
        }
    }
}
