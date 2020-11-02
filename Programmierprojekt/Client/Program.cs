using System;
//MAYER Tamara
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

                    Client client = new Client();
                    client.Start(port);
                }
            }
            else
            {
                Client client = new Client();
                client.Start(19);
            }
        }
    }
}
