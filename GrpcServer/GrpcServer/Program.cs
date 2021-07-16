using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Server server = new Server()
            {
                Ports = { new ServerPort("localhost", 5000, null) },
            };

            server.Start();
            Console.WriteLine("Server started without credentials");
        }
    }
}
