using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataCommProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Router R1 = new Router();
            Switch s1 = new Switch(R1);
            Client c1 = new Client(s1,"55:22:ff:22:ff:aa:");
            Client c2 = new Client(s1,"BB:21:52:cc:68:af");
            c1.ping(c2.IpAddress);
            Console.ReadLine();
        }
    }
}
