using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataCommProject
{
    interface Networkable
    {
        IPAddress IpAddress { get; set; }
        string MacAddress { get; set; }
        Dictionary<IPAddress,string> ArpTable { get; set; }
    }
}
