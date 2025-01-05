using FinalApiTask.BL.ExternalServices.Implentations;
using FinalApiTask.BL.ExternalServices.Interfaces;
using FinalApiTask.BL.Services.Abstractions;
using FinalApiTask.BL.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FinalApiTask.BL
{
    public static class ConfigurationServices
    {
        public static void AddBLServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISizeService, SizeService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();


        }
    }
}
