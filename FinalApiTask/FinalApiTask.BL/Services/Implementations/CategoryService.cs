using AutoMapper;
using FinalApiTask.BL.DTOs.AppUserDtos;
using FinalApiTask.BL.DTOs.CategoryDtos;
using FinalApiTask.BL.Services.Abstractions;
using FinalApiTask.Core.Entities;
using FinalApiTask.DAL.Repositories.Abstractions;
using FinalApiTask.DAL.Repositories.Implementations;

namespace FinalApiTask.BL.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepo categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }


        public async Task<Category> CreateAsync(CategoryCreateDto entityDto)
        {
            Category createdCategory = _mapper.Map<Category>(entityDto);
            createdCategory.CreatedAt = DateTime.UtcNow.AddHours(4);
            var createdEntity = await _categoryRepo.CreateAsync(createdCategory);
            await _categoryRepo.SaveChangesAsync();
            return createdEntity;
        }


        public async Task<ICollection<Category>> GetAllAsync()
        {
            return await _categoryRepo.GetAllAsync();
        }


        public async Task<Category> GetByIdAsync(int id)
        {
            if (!await _categoryRepo.IsExistsAsync(id))
            {
                throw new EntryPointNotFoundException();
            }
            return await _categoryRepo.GetByIdAsync(id);
        }


        public async Task<bool> SoftDeleteAsync(int id)
        {
            var categoryEntity = await GetByIdAsync(id);
            _categoryRepo.SoftDelete(categoryEntity);
            await _categoryRepo.SaveChangesAsync();
            return true;
        }


        public async Task<bool> UpdateAsync(int id, CategoryCreateDto categoryUpdateDto)
        {
            var categoryEntity = await GetByIdAsync(id);
            Category updatedCategory = _mapper.Map<Category>(categoryUpdateDto);
            updatedCategory.UpdatedAt = DateTime.UtcNow.AddHours(4);
            updatedCategory.Id = id;
            _categoryRepo.Update(updatedCategory);
            await _categoryRepo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditAsync(int id, CategoryEditDto categoryEditDto)
        {
            var categoryEntity = await GetByIdAsync(id);
            _mapper.Map(categoryEditDto, categoryEntity);
            categoryEntity.UpdatedAt = DateTime.UtcNow.AddHours(4);
            _categoryRepo.Update(categoryEntity);
            await _categoryRepo.SaveChangesAsync();
            return true;
        }
    }
}
