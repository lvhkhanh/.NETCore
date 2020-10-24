using System;

using System.Threading;

using System.Threading.Tasks;

using Grpc.Core;

using Grpc.Net.Client;

namespace Client

{

    public class Program

    {

        static async Task Main(string[] args)

        {

            var channel = GrpcChannel.ForAddress("https://localhost:5001");

            var client = new Products.Products.ProductsClient(channel);

            await UnaryCallExample(client);

            Console.WriteLine("Shutting down");

            Console.WriteLine("Press any key to exit...");

            Console.ReadKey();

        }

        private static async Task UnaryCallExample(Products.Products.ProductsClient client)

        {

            var reply = await client.GetProductAsync(new Products.ProductRequest { ProductId = "12345" });

            Console.WriteLine("Product: " + reply.ProductName);

        }

    }

}