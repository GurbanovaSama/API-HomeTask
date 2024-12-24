using Microsoft.Extensions.DependencyInjection;
using WorkShopManagement.BL.Services.Abstractions;
using WorkShopManagement.BL.Services.Implementations;

namespace WorkShopManagement.BL.Services
{
    public static class ConfigurationServices
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IParticipantService, ParticipantService>();

            services.AddScoped<IWorkShopService, WorkShopService>();
        }
    }
}
