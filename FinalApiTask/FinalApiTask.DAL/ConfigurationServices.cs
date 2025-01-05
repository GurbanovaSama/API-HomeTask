using FinalApiTask.DAL.Repositories.Abstractions;
using FinalApiTask.DAL.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace FinalApiTask.DAL
{
    public static class ConfigurationServices
    {
        public static void AddDALServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IColorRepo, ColorRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<ISizeRepo, SizeRepo>();
        }
    }
}
