using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataCommProject
{
    class Router : Networkable
    {
        public IPAddress IpAddress{ get; set; }
        public string MacAddress { get; set; }
        public Dictionary<IPAddress, string> ArpTable { get; set; }

        public Router()
        {
            // Static Ip address for the router
            IpAddress = IPAddress.Parse("192.168.1.1");
            MacAddress = "48:F8:B3:37:A6:04"; // just create a static MacAddress
        }
        
    }
}
