using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                if (Int32.TryParse(args[0], out int port))
                {

                    Server server = new Server();
                    server.Start(port);
                }
            }
            else
            {
                Server server = new Server();
                server.Start(19);
            }
        }
    }
}
