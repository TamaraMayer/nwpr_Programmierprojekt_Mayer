using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

//MAyer Tamara
namespace Server
{
    class Server
    {
        private BinaryFormatter binaryFormatter = new BinaryFormatter();
        private TcpListener tcpListener;

        public void Start(int port)
        {
            this.tcpListener = this.CreateTCPListener(port);
            this.WatchStream();
        }

        private TcpListener CreateTCPListener(int port)
        {
            try
            {
                return new TcpListener(IPAddress.Any, port);
            }
            catch
            {
                Console.WriteLine($"Server cannot be created with this port {port}");
                Console.ReadLine();
                Environment.Exit(0);
            }

            return new TcpListener(IPAddress.Any, 0);
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

                Thread t = new Thread(WatchConnection);
                t.Start(client);


            }
        }

        private  void WatchConnection(object arg)
        {
            TcpClient client = arg as TcpClient;


            try
            {
                while (true)
                {
                    Thread.Sleep(100);

                    if (client.Available > 0)
                    {
                        string s = RFC.RFC_Protocol.GenerateData();

                        binaryFormatter.Serialize(client.GetStream(),s );
                    }
                    else
                    {
                        binaryFormatter.Serialize(client.GetStream(),"");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Client got disconnected");
                client.Dispose();
            }
        }

    } 

}
