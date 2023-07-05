using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreNet.Domain.Interfaces;
using StoreNet.Infrastructure;
using StoreNet.Infrastructure.Repositories;
using StoreNet.Domain.Interfaces.Services;
using StoreNet.Service;


namespace StoreNet.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreNetContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<Func<StoreNetContext>>((provider) => () => provider.GetService<StoreNetContext>());
            services.AddScoped<DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddDIServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<IProductStoreService, ProductStoreService>();
            return services;
        }
    }
}
