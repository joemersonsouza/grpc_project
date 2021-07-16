using Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.GetAll
{
    public interface IGetAllProduct
    {
        Task<List<Product>> HandleAsync(Guid userId);
    }
}
