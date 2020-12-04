using System;

//Tamara Mayer
namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Client client = new Client();
                client.Start(19);

                Environment.Exit(0);
            }
            else if (args.Length == 1)
            {
                if (Int32.TryParse(args[0], out int port))
                {
                    Client client = new Client();
                    client.Start(port);

                    Environment.Exit(0);
                }
            }
           
                Console.WriteLine("Something wrong with your start Parameters, please check them and try again! \r\n Press enter!");
                Console.ReadLine();
            
        }
    }
}
