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

            tcpClient.Connect("127.0.0.1",port);

            Thread thread = new Thread(this.Listen);
            thread.IsBackground = true;
            thread.Start();

            Console.WriteLine("Press escape to end the service, Press Enter to send a new message");

            ConsoleKey key = Console.ReadKey().Key;

            while (key != ConsoleKey.Escape)
            {
                if (key == ConsoleKey.Enter)
                {
                    this.SendMessage();
                }

                Console.ReadKey();
            }

            Console.WriteLine("Program will be terminated!");
            tcpClient.Dispose();

            Thread.Sleep(2000);
        }

        private void SendMessage()
        {
            string s = RFC.RFC_Protocol.GenerateData();

            binaryFormatter.Serialize(tcpClient.GetStream(), s);
        }

        public void Listen()
        {
           
            try
            {
                if (tcpClient.Available > 0)
                {
                    string s = RFC.RFC_Protocol.GenerateData();

                    binaryFormatter.Serialize(tcpClient.GetStream(), s);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Some error happend when sending. please press enter to end the application");
                while (Console.ReadKey().Key != ConsoleKey.Enter) ;
                Environment.Exit(1);
            }
        }
    }
}
