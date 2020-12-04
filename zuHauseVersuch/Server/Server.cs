using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    public class Server
    {
        public void Start(int port)
        {
            try
            {

                TcpListener tcpListener = new TcpListener(IPAddress.Any, port);
                tcpListener.Start();

                Console.WriteLine("Server started");

                while (true)
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    Thread t = new Thread(CommunicateWithClient);
                    t.Start(client);
                }
            }
            catch(Exception e)
            {

            }

        }

        private void CommunicateWithClient(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
