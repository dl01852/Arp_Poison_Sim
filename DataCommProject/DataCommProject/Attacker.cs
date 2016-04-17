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
    class Attacker : Networkable
    {
        private Router r;
        Switch s;
        public IPAddress IpAddress { get; set; }
        public IPAddress DefaultGateWay { get; set; }
        public string MacAddress { get; set; }
        public Dictionary<IPAddress,string> ArpTable { get; set; }
        private static Random _randomIp;

        public Attacker(Router router, Switch S)
        {
            ArpTable = new Dictionary<IPAddress, string>();
            IpAddress = IPAddress.Parse(string.Format("192.168.{0}.{1}", _randomIp.Next(0, 255), _randomIp.Next(0, 255)));
            r = router;
            s = S;
        }

      
        public void ping(IPAddress ip)
        {
            // do some bad stuff!
        }

        public void getClientsConnected()
        {
            Client[] clients = s.GetAllClients().ToArray();

            foreach (Client c in clients)
            {
                ArpTable.Add(c.IpAddress,c.MacAddress);
            }
        }


        //todo poison a client by changing the ARP table of the router to the Attackers IP address.
        //todo Also have to populate the Router's Table.
        //todo then maybe try to go to a web browser via webclient.
        public void poisonClient(IPAddress ipAddress)
        {


            Client c = s.GetAllClients().Find(client => client.IpAddress.Equals(ipAddress));
            c.DefaultGateWay = this.IpAddress; // change the default GateWay of the clients to this IP ADDRESS
            //s.GateWay.ArpTable[ip]
        }
    }
}
