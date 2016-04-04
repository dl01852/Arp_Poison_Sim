using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataCommProject
{
    class Router
    {
        public IPAddress GatewayAddress { get; set; }

        public Router()
        {
            // Static Ip address for the router
            GatewayAddress = IPAddress.Parse("192.168.1.1");
        }
    }
}
