using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                if (Int32.TryParse(args[0], out int port))
                {
                    Client client = new Client(100);
                    client.Start(port);
                }
            }
            else if (args.Length == 2)
            {
                if (Int32.TryParse(args[0], out int port) && Int32.TryParse(args[1], out int delayTime))
                {
                    Client client = new Client(delayTime);
                    client.Start(port);
                }
            }
            else
            {
                Client client = new Client(100);
                client.Start(19);
            }
        }
    }
}
