﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataCommProject
{
    class Client : Networkable
    {
        public IPAddress IpAddress { get; set; }
        public IPAddress DefaultGateWay { get; set; }
        public string MacAddress { get; set; }
        public Dictionary<IPAddress, string> ArpTable { get; set; } // each client has an ARP table  maps a Client to a macAddress
        private readonly Switch _switchConnected; // this is the switch the Client is connected to.
        private static  Random _randomIp = new Random(); // random is static so you don't get same seeding when creating instances. 

        public Client(Switch s, string macAddress)
        {
            _switchConnected = s; // link this client to a switch. 
            _switchConnected.AddClient(this);
            MacAddress = macAddress;
            ArpTable = new Dictionary<IPAddress, string>();
            DefaultGateWay = _switchConnected.getDefaultGateWay();
            IpAddress = IPAddress.Parse(string.Format("192.168.{0}.{1}", _randomIp.Next(0, 255), _randomIp.Next(0, 255))); // generates randomIP in the 192.16.x.x
                
        }

        public void ping(IPAddress ip)
        {
            // checks my arpTable for the given IP
            var bleh = ArpTable.FirstOrDefault(client => client.Key.Equals(ip));

            if (bleh.Key == null) // if we don't have the IP, Broadcast. 
            {
                var foundClient = _switchConnected.BroadCast(ip.ToString()); // find the client through broadcast.
                if (foundClient != null)
                {
                    ArpTable.Add(foundClient.IpAddress, foundClient.MacAddress); // update the this.ArpTable
                    foundClient.ArpTable.Add(IpAddress, MacAddress); // update the found Clients table.
                }
                else
                {
                    Console.WriteLine("Client not found....");
                    return;
                }
                Console.WriteLine("Found Client...\nPinging {0}", ip);
            }
            else
            {
                // ping the other user
                Console.WriteLine("Pinging {0}", ip);
            }
        }
    }
}
