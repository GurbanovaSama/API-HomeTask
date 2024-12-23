using AutoMapper;
using RepositoryPatternTask.BL.DTOs.DepartmentDtos;
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
    }
}
