using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckLogsApatch
{
    public class FilterProps
    {
        public string path { get; set; } = string.Empty;
        public string ip { get; set; } = string.Empty;
        public int responseStatus { get; set; } = -1;

        public FilterProps()
        {

        }

        public override string ToString()
        {
            return $"[applyFilters] ip = {ip} name = {path} reponse status = {responseStatus}";
        }
    }
}
