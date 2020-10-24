using System.Threading.Tasks;

using Products;

using Grpc.Core;

using Microsoft.Extensions.Logging;

namespace HelloRealWorldWebAPI

{

    public class ProductsService : Products.Products.ProductsBase

    {

        private readonly ILogger _logger;

        public ProductsService(ILoggerFactory loggerFactory)

        {

            _logger = loggerFactory.CreateLogger<ProductsService>();

        }

        public override Task<ProductReply> GetProduct(ProductRequest request, ServerCallContext context)

        {

            _logger.LogInformation($"Sending product with id {request.ProductId }");

            return Task.FromResult(new ProductReply { ProductName = "Bike", Price = "5000€" });

        }

    }

}