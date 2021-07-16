using System;
using System.Threading.Tasks;
using Application.GetAll;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcController.Controller
{
    public class ProductController : Product.ProductBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IGetAllProduct getAllProduct;
        public ProductController(ILogger<ProductController> logger, IGetAllProduct getAllProduct)
        {
            _logger = logger;
            this.getAllProduct = getAllProduct;
        }

        public override Task GetAll(GetAllRequest request, IServerStreamWriter<GetAllResponse> responseStream, ServerCallContext context)
        {
            var response = new GetAllResponse();
            try
            {
                var products = getAllProduct.HandleAsync(Guid.Parse(request.UserId)).Result;
                products.ForEach(x =>
                {
                    response.Products.Add(
                        new ProductOverview()
                        {
                            Price = x.Price,
                            Name = x.Name,
                            Description = x.Description
                        }
                    );
                });
            } catch (Exception e)
            {
                response.HasError = true;
                response.ErrorMessage = e.Message;
            }

            responseStream.WriteAsync(response);
            return Task.CompletedTask;
        }
    }
}
