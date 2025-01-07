using HospitalManagement.BL.DTOs.PatientDtos;
using HospitalManagement.Core.Entities;

namespace HospitalManagement.BL.Services.Abstractions
{
    public interface IPatientService
    {
        Task<ICollection<Patient>> GetALLAsync();
        Task<Patient> CreateAsync(PatientCreateDto entityDto);
        Task<Patient> GetByIdAsync(int id);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> UpdateAsync(int id, PatientCreateDto patientUpdateDto);
    }
}
