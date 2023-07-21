using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreNet.Domain.Interfaces;
using StoreNet.Domain.Interfaces.Repositories;
using StoreNet.Domain.Interfaces.Services;
using StoreNet.Infrastructure;
using StoreNet.Infrastructure.Extensions.Users;
using StoreNet.Service;

namespace StoreNet.Application
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreNetContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("StoreNetDB"));
            });

            services.AddScoped<Func<StoreNetContext>>((provider) => () => provider.GetService<StoreNetContext>());
            services.AddScoped<DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUnitOfWorkUser, UnitOfWorkUser>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<IProductStoreService, ProductStoreService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
