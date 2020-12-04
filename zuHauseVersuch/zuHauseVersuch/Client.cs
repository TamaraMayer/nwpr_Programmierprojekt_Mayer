using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
   public class Client
    {
        public Client()
        {

        }

        internal void Start(int port)
        {
            IPAddress ip_adress = IPAddress.Parse("127.0.0.1");
            //    try
            //    {

            TcpClient tcpClient = new TcpClient(ip_adress.ToString(), port);
            Console.WriteLine("Connection successful");
            Console.WriteLine("Enter 'Exit' to teminate");

            StreamReader reader = new StreamReader(tcpClient.GetStream());

            while (true)
            {
                string serverString = reader.ReadLine();
                Console.WriteLine(serverString);
            }

            reader.Close();
            tcpClient.Close();
            //}
            //catch(Exception e)
            //{

            //}
        }
    }
}
