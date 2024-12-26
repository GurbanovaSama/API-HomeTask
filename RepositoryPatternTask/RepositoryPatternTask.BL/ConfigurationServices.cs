using Microsoft.Extensions.DependencyInjection;
using RepositoryPatternTask.BL.ExternalServices.Implentations;
using RepositoryPatternTask.BL.ExternalServices.Interfaces;
using RepositoryPatternTask.BL.Services.Abstractions;
using RepositoryPatternTask.BL.Services.Implementations;

namespace RepositoryPatternTask.BL
{
    public static class ConfigurationServices
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
        }
    }
}
