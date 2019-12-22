using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CheckLogsApatch
{
    public class Log
    {
        public static Dictionary<string, int> monthIndexs = new Dictionary<string, int>
        {
            { "Jan", 1 },
            { "Feb", 2 },
            { "Mar", 3 },
            { "Apr", 4 },
            { "May", 5 },
            { "Jun", 6 },
            { "Jul", 7 },
            { "Aug", 8 },
            { "Sep", 9 },
            { "Oct", 10 },
            { "Nov", 11 },
            { "Dec", 12 }
        };

        public static Regex regex = new Regex("^(::)?(.+) - - \\[(.+)\\] \"(.+) (.+) (.+)\" (\\d+) (\\d+)", RegexOptions.IgnoreCase);

        public string rawLogLine = string.Empty;

        public string ip { get; set; } = string.Empty;
        public DateTime date { get; set; }
        public string method { get; set; } = string.Empty;
        public string path { get; set; } = string.Empty;
        public string protocol { get; set; } = string.Empty;
        public int responseStatus { get; set; }
        public int responseSize { get; set; }
        public bool accessError { get; set; }

        public Log(string logLine)
        {
            rawLogLine = logLine;
            parseLog();
        }

        public void parseLog()
        {
            MatchCollection matches = regex.Matches(rawLogLine);

            foreach (Match match in matches)
            {
                ip = match.Groups[2].Value;
                date = parseDateLog(match.Groups[3].Value);
                method = match.Groups[4].Value;
                path = match.Groups[5].Value;
                protocol = match.Groups[6].Value;

                responseStatus = int.Parse(match.Groups[7].Value);
                responseSize = int.Parse(match.Groups[8].Value);
            }
        }

        public DateTime parseDateLog(string dateLog)
        {
            Regex regDate = new Regex(@"(\d+)/(\w+)/(\d+):(\d+):(\d+):(\d)", RegexOptions.IgnoreCase);

            MatchCollection matches = regDate.Matches(dateLog);

            foreach (Match match in matches)
            {
                int day = int.Parse(match.Groups[1].Value);
                int month = monthIndexs[match.Groups[2].Value];
                int year = int.Parse(match.Groups[3].Value);

                int hours = int.Parse(match.Groups[4].Value);
                int minutes = int.Parse(match.Groups[5].Value);
                int seconds = int.Parse(match.Groups[6].Value);

                return new DateTime(year, month, day, hours, minutes, seconds);
            }

            Console.WriteLine("[parseDateLog] invalid date " + dateLog);

            return new DateTime();
        }

        public bool testLogFilter(FilterProps filter)
        {
            if (filter.responseStatus != responseStatus && filter.responseStatus != -1)
            {
                return false;
            }

            if (filter.date > date)
            {
                return false;
            }

            var regIP = new Regex(filter.ip);

            if (!regIP.IsMatch(ip))
            {
                return false;
            }

            var regPath = new Regex(filter.path);

            if (!regPath.IsMatch(path))
            {
                return false;
            }

            return true;
        }

        public static bool testLog(string rawLog)
        {
            return regex.IsMatch(rawLog) && (rawLog.IndexOf("\"GET /favicon.ico ") == -1);
        }

        public override string ToString()
        {
            return $"[IP=] {ip} [DATE=] {date} [METHOD=] {method} [PATH=] {path} [PROTOCOL=] {protocol} [STATUS=] {responseStatus} [SIZE=] {responseSize}\n";
        }
    }
}
