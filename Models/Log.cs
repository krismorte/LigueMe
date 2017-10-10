using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ligueme.Models
{
    public class Log
    {
        public Log()
        {
            dateHour = DateTime.Now;
        }

        public int level { get; set; }
        public string userLogged = "PORTAL";
        public DateTime dateHour { get; set; }
        public string hostname = "GT-9762S";
        public string message { get; set; }
        public string data { get; set; }
        public string applicationId = "AC172F75-8B53-449D-941F-B092E291075B";
        public string IP = "192.168.114.3";

    }
}