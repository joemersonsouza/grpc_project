using Application.GetAll;
using Core.Repository;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace Infrastructure.Extensions
{
    public static class RegisterExtension
    {
        public static void AddAllComponents(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGetAllProduct, GetAllProduct>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
