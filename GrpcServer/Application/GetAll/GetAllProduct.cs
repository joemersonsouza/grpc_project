using Core;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.GetAll
{
    public class GetAllProduct : IGetAllProduct
    {
        private readonly IUserRepository userRepository;
        private readonly IProductRepository productRepository;

        public GetAllProduct(IUserRepository userRepository, IProductRepository productRepository)
        {
            this.userRepository = userRepository;
            this.productRepository = productRepository;
        }

        public async Task<List<Product>> HandleAsync(Guid userId)
        {
            var user = await userRepository.GetUserByIdAsync(userId);
            if(user == null)
            {
                throw new ArgumentException("Invalid User");
            }

            return await productRepository.GetAllAsync();
        }
    }
}
