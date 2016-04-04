using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataCommProject
{
    class Switch
    {
        private readonly List<Client> _clientsConnected;
        private Router GateWay;

        public Switch(Router GateWay)
        {
            this.GateWay = GateWay; // link a Switch to a Router.... 
            _clientsConnected = new List<Client>(); // switches have to have clients connected to....
        }

        public void AddClient(Client c)
        {
            _clientsConnected.Add(c);
        }

        public Client BroadCast(string ipAddress)
        {
            // LINQ statement to broadcast to all clients and return the IPaddress that matches with the broadcast. 
            return _clientsConnected.FirstOrDefault(c => c.IpAddress.Equals(IPAddress.Parse(ipAddress)));
        }
    }
}
