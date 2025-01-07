using AutoMapper;
using HospitalManagement.BL.DTOs.InsuranceDtos;
using HospitalManagement.BL.Exceptions.CommonExceptions;
using HospitalManagement.BL.Services.Abstractions;
using HospitalManagement.Core.Entities;
using HospitalManagement.DAL.Repositories.Abstractions;

namespace HospitalManagement.BL.Services.Implementations
{
    public class InsuranceService : IInsuranceService
    {
        private readonly IInsuranceRepository _insuranceRepo;
        private readonly IMapper _mapper;
        public InsuranceService(IInsuranceRepository insuranceRepo, IMapper mapper)
        {
            _insuranceRepo = insuranceRepo;
            _mapper = mapper;
        }



        public  async Task<Insurance> CreateAsync(InsuranceCreateDto entityDto)
        {
            Insurance createdInsurance = _mapper.Map<Insurance>(entityDto);
            createdInsurance.CreatedAt = DateTime.UtcNow.AddHours(4);
            Insurance insuranceEntity = await _insuranceRepo.CreateAsync(createdInsurance);
            await _insuranceRepo.SaveChangesAsync();
            return insuranceEntity;
        }

        public  async Task<ICollection<Insurance>> GetALLAsync()
        {
            return await _insuranceRepo.GetAllAsync();
        }

        public async Task<Insurance> GetByIdAsync(int id)
        {

            if (!await _insuranceRepo.IsExistsAsync(id))
            {
                throw new EntityNotFoundException();
            }
            return await _insuranceRepo.GetByIdAsync(id);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var insuranceEntity = await GetByIdAsync(id);
            _insuranceRepo.SoftDelete(insuranceEntity);
            await _insuranceRepo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, InsuranceCreateDto insuranceUpdateDto)
        {
            var insuranceEntity = await GetByIdAsync(id);
            Insurance updatedInsurance = _mapper.Map<Insurance>(insuranceUpdateDto);
            updatedInsurance.CreatedAt = DateTime.UtcNow.AddHours(4);
            updatedInsurance.Id = id;
            _insuranceRepo.Update(updatedInsurance);
            await _insuranceRepo.SaveChangesAsync();
            return true;
        }
    }
}
