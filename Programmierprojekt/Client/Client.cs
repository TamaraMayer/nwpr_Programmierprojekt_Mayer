using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace Client
{
    class Client
    {
       private TcpClient tcpClient;
        private BinaryFormatter binaryFormatter = new BinaryFormatter();

        public void Start(int port)
        {
            tcpClient = new TcpClient();

            tcpClient.Connect(IPAddress.Any,port);

            //Thread thread = new Thread(this.Listen);
            //thread.IsBackground = true;
            //thread.Start();


            ConsoleKey key = Console.ReadKey().Key;

            while (key != ConsoleKey.Escape)
            {
                if (key == ConsoleKey.Enter)
                {
                    this.SendMessage();
                }

                Console.ReadKey();
            }


        }

        private void SendMessage()
        {
            string s = RFC.RFC_Protocol.GenerateData();

            binaryFormatter.Serialize(tcpClient.GetStream(), s);
        }
    }
}
