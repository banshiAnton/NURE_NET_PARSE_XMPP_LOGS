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
        public static Regex regex = new Regex("^(::)?(.+) - - \\[(.+)\\] \"(.+) (.+) (.+)\" (\\d+) (\\d+)", RegexOptions.IgnoreCase);

        public string rawLogLine = string.Empty;

        public string ip { get; set; } = string.Empty;
        public string date { get; set; } = string.Empty;
        public string method { get; set; } = string.Empty;
        public string path { get; set; } = string.Empty;
        public string protocol { get; set; } = string.Empty;
        public int responseStatus { get; set; }
        public int responseSize { get; set; }

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
                date = match.Groups[3].Value;
                method = match.Groups[4].Value;
                path = match.Groups[5].Value;
                protocol = match.Groups[6].Value;

                responseStatus = int.Parse(match.Groups[7].Value);
                responseSize = int.Parse(match.Groups[8].Value);
            }
        }

        public static bool testLog(string rawLog)
        {
            return regex.IsMatch(rawLog);
        }

        public override string ToString()
        {
            return $"[IP=] {ip} [DATE=] {date} [METHOD=] {method} [PATH=] {path} [PROTOCOL=] {protocol} [STATUS=] {responseStatus} [SIZE=] {responseSize}\n";
        }
    }
}
