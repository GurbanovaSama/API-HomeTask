using AutoMapper;
using RepositoryPatternTask.BL.DTOs.DepartmentDtos;
using RepositoryPatternTask.BL.Exceptions.CommonExceptions;
using RepositoryPatternTask.BL.Services.Abstractions;
using RepositoryPatternTask.Core.Entities;
using RepositoryPatternTask.DAL.Repositories.Abstractions;

namespace RepositoryPatternTask.BL.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepo;
        private readonly IMapper _mapper;   

        public DepartmentService(IDepartmentRepository departmentRepo, IMapper mapper)
        {
            _departmentRepo = departmentRepo;
            _mapper = mapper;   
        }

        public async Task<ICollection<Department>> GetALLAsync()
        {
            return await _departmentRepo.GetAllAsync();
        }


        public async Task<Department> CreateAsync(DepartmentCreateDto entityDto)
        {
            Department createdDepartment = _mapper.Map<Department>(entityDto);
            createdDepartment.CreatedAt = DateTime.UtcNow.AddHours(4);
            Department departmentEntity = await _departmentRepo.CreateAsync(createdDepartment);
            await _departmentRepo.SaveChangesAsync(); 
            return departmentEntity;
        }



        public async Task<Department> GetByIdAsync(int id)
        {
            if (!await _departmentRepo.IsExistsAsync(id))
            {
                throw new EntityNotFoundException();
            }
            return await _departmentRepo.GetByIdAsync(id);
        }



        public async Task<bool> SoftDeleteAsync(int id)
        {
            var departmentEntity = await GetByIdAsync(id);
            _departmentRepo.SoftDelete(departmentEntity);   
            await _departmentRepo.SaveChangesAsync();
            return true;
        }




        public async Task<bool> UpdateAsync(int id, DepartmentCreateDto departmentUpdateDto)
        {
            var departmentEntity = await GetByIdAsync(id);
            Department updatedDepartment = _mapper.Map<Department>(departmentUpdateDto);
            updatedDepartment.CreatedAt = DateTime.UtcNow.AddHours(4);
            updatedDepartment.Id = id;  
            _departmentRepo.Update(updatedDepartment);  
            await _departmentRepo.SaveChangesAsync();
            return true;
        }
    }
}
