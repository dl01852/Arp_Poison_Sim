using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace DataCommProject

    //todo: maybe have a queue of request for when the client wants to go out to the web, it'll come through this client first.
    // todo: a fucntion that infilitrates a clients GateWay Address and then a function in the client class to go to the Web......
{
    class Attacker : Iclientable
    {
        private Router r;
        Switch s;
        public IPAddress IpAddress { get; set; }
        public IPAddress DefaultGateWay { get; set; }
        public string MacAddress { get; set; }
        public double SubnetMask { get; set; }
        public Dictionary<IPAddress,string> ArpTable { get; set; }
        private static Random _randomIp;

        public Attacker(Router router, Switch S)
        {
            ArpTable = new Dictionary<IPAddress, string>();
            IpAddress = IPAddress.Parse(string.Format("192.168.{0}.{1}", _randomIp.Next(0, 255), _randomIp.Next(0, 255)));
        }

      
        public void ping(IPAddress ip)
        {
            // do some bad stuff!
        }
    }
}
