using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Application.Interfaces;
using ECommerceWeb.Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using ECommerceWeb.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWeb.Infrastructure
{
    public static class InterfaceServiceRegistration
    {
        public static IServiceCollection AddInterfaceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ECommerceWebAppConnString"));


            });
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            return services;

        }
    }
}
