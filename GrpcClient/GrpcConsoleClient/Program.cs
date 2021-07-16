using Grpc.Core;
using Grpc.Net.Client;
using GrpcClient;
using System;
using System.Threading.Tasks;

namespace GrpcConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await GetProducts("026b97e2-50a3-41ba-83d9-a796f1b624b1");
            await GetProducts(Guid.NewGuid().ToString());
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static async Task GetProducts(string userId)
        {
            Console.WriteLine("Starting the client...");
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Product.ProductClient(channel);

            Console.WriteLine("Sending request...");
            var request = new GetAllRequest() { UserId = userId };
            using var result = client.GetAll(request);
            var responseStream = result.ResponseStream;
            while (await responseStream.MoveNext())
            {
                if(result.ResponseStream.Current.HasError)
                    Console.WriteLine(result.ResponseStream.Current.ErrorMessage);
                else
                    Console.WriteLine(result.ResponseStream.Current.Products);
            }

            Console.WriteLine("End of message...\n\n");
        }
    }
}
