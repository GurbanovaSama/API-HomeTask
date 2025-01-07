using HospitalManagement.BL.Services.Abstractions;
using HospitalManagement.BL.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.BL
{
    public static class ConfigurationServices
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IInsuranceService, InsuranceService>();
        }
    }
}
