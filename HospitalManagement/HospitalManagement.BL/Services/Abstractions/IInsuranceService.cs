using HospitalManagement.BL.DTOs.InsuranceDtos;
using HospitalManagement.BL.DTOs.PatientDtos;
using HospitalManagement.Core.Entities;

namespace HospitalManagement.BL.Services.Abstractions
{
    public interface IInsuranceService
    {
        Task<ICollection<Insurance>> GetALLAsync();
        Task<Insurance> CreateAsync(InsuranceCreateDto entityDto);
        Task<Insurance> GetByIdAsync(int id);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> UpdateAsync(int id, InsuranceCreateDto insuranceUpdateDto);
    }
}
