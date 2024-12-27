using ECommerceApi.BL.Services.Abstractions;
using ECommerceApi.BL.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceApi.BL.Services
{
    public static class ConfigurationServices
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IOrderService, OrderService>();  


        }
    }
}
