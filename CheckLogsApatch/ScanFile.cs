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
            var file = new StreamReader(path);
            string line = string.Empty;
            while ((line = file.ReadLine()) != null)
            {
                parseLogLine(line);
                // Console.WriteLine("[checkFileByDefaultPath]: Line: " + line);
            }
        }

        public void parseLogLine(string log)
        {
            var regex = new Regex("^(::)?(.+) - - \\[(.+)\\] \"(.+) (.+) (.+)\" (\\d+) (\\d+)", RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(log);

            foreach (Match match in matches)
            {
                Console.WriteLine($"[IP=] {match.Groups[2].Value} [DATE=] {match.Groups[3].Value} [METHOD=] {match.Groups[4].Value} [PATH=] {match.Groups[5].Value} [PROTOCOL=] {match.Groups[6].Value} [STATUS=] {match.Groups[7].Value} [SIZE=] {match.Groups[8].Value}\n");
            }
        }
    }
}
