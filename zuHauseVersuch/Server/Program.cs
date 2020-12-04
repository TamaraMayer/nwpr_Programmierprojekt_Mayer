using System;

//Tamara Mayer
namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Server server = new Server(100);
                server.Start(19);

                Environment.Exit(0);
            }
            else if (args.Length == 1)
            {
                if (Int32.TryParse(args[0], out int port))
                {
                    Server server = new Server(100);
                    server.Start(port);

                    Environment.Exit(0);
                }
            }
            else if (args.Length == 2)
            {
                if (Int32.TryParse(args[0], out int port) && Int32.TryParse(args[1], out int delayTime))
                {
                    Server server = new Server(delayTime);
                    server.Start(port);

                    Environment.Exit(0);
                }
            }

                Console.WriteLine("Something wrong with your start Parameters, please check them and try again!");
        }
    }
}
