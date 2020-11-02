using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

//MAyer Tamara
namespace Server
{
    class Server
    {
        private TcpListener tcpListener;

        public void Start(int port)
        {
            this.tcpListener = this.CreateTCPListener(port);
        }

        private TcpListener CreateTCPListener(int port)
        {
            try
            {
                return new TcpListener(IPAddress.Any, port);
            }
            catch
            {

                Console.ReadLine();
                Environment.Exit(0);
            }

            return new TcpListener(IPAddress.Any, 19);
        }

        private void WatchStream()
        {
            TcpClient client = new TcpClient();

            try
            {
                this.tcpListener.Start();
            }
            catch (SocketException)
            {
                    Console.WriteLine("The server cannot be started! A server with the same IP Adress or Port is already active");
                

                return;
            }


            while (true)
            {
                client = this.tcpListener.AcceptTcpClient();
            }
            }
        }
}
