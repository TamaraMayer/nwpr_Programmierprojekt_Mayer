using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

//Tamara Mayer
namespace Server
{
    public class Server
    {
        private string[] asciiLines;
        private int delayTime;

        public Server(int delayTime)
        {
            this.delayTime = delayTime;

            asciiLines = new string[72];

            SetAsciiLines();
        }

        private void SetAsciiLines()
        {
            using (StringReader reader = new StringReader(RFC_Protokoll.RFC.GetAllLines()))
            {
                for (int i = 0; i < 72; i++)
                {
                    asciiLines[i] = reader.ReadLine();
                }
            }
        }

        public void Start(int port)
        {
            //    try
            //    {

            TcpListener tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();

            Console.WriteLine("Server started");

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                Console.WriteLine("New Client connected");
                Thread t = new Thread(CommunicateWithClient);
                t.Start(client);
            }
            //}
            //catch(Exception e)
            //{

            //}
        }

        private void CommunicateWithClient(object obj)
        {
            int counter = 0;
            TcpClient client = obj as TcpClient;

            try
            {
                StreamWriter writer = new StreamWriter(client.GetStream());

                while (true)
                {
                    writer.WriteLine(this.asciiLines[counter % 72]);
                    writer.Flush();


                    counter++;
                    Thread.Sleep(this.delayTime);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("It appears like a client got disconnected");
                return;
            }
            finally
            {
                if (client != null)
                {
                    client.Close();
                }
            }
        }
    }
}
