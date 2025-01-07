using AutoMapper;
using HospitalManagement.BL.DTOs.PatientDtos;
using HospitalManagement.BL.Exceptions.CommonExceptions;
using HospitalManagement.BL.Services.Abstractions;
using HospitalManagement.Core.Entities;
using HospitalManagement.DAL.Repositories.Abstractions;

namespace HospitalManagement.BL.Services.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepo;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepo, IMapper mapper)
        {
            _patientRepo = patientRepo;
            _mapper = mapper;
        }

        public async Task<Patient> CreateAsync(PatientCreateDto entityDto)
        {
            Patient createdPatient = _mapper.Map<Patient>(entityDto);
            createdPatient.CreatedAt = DateTime.UtcNow.AddHours(4);
            Patient patientEntity = await _patientRepo.CreateAsync(createdPatient);
            await _patientRepo.SaveChangesAsync();
            return patientEntity;
        }

        public async Task<ICollection<Patient>> GetALLAsync()
        {
            return await _patientRepo.GetAllAsync();
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            if (!await _patientRepo.IsExistsAsync(id))
            {
                throw new EntityNotFoundException();
            }
            return await _patientRepo.GetByIdAsync(id);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var patientEntity = await GetByIdAsync(id);
            _patientRepo.SoftDelete(patientEntity);
            await _patientRepo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, PatientCreateDto patientUpdateDto)
        {
            var patientEntity = await GetByIdAsync(id);
            Patient updatedPatient = _mapper.Map<Patient>(patientUpdateDto);
            updatedPatient.CreatedAt = DateTime.UtcNow.AddHours(4);
            updatedPatient.Id = id;
            _patientRepo.Update(updatedPatient);
            await _patientRepo.SaveChangesAsync();
            return true;
        }
    }
}
