using AutoMapper;
using FinalApiTask.BL.DTOs.ProductDtos;
using FinalApiTask.BL.DTOs.SizeDtos;
using FinalApiTask.BL.Services.Abstractions;
using FinalApiTask.Core.Entities;
using FinalApiTask.DAL.Repositories.Abstractions;
using FinalApiTask.DAL.Repositories.Implementations;

namespace FinalApiTask.BL.Services.Implementations
{
    public class SizeService : ISizeService
    {
        private readonly ISizeRepo _sizeRepo;
        private readonly IMapper _mapper;
        public SizeService(ISizeRepo sizeRepo, IMapper mapper)
        {
            _sizeRepo = sizeRepo;
            _mapper = mapper;
        }


        public async Task<Size> CreateAsync(SizeCreateDto entityDto)
        {
            Size createdSize = _mapper.Map<Size>(entityDto);
            createdSize.CreatedAt = DateTime.UtcNow.AddHours(4);
            var createdEntity = await _sizeRepo.CreateAsync(createdSize);
            await _sizeRepo.SaveChangesAsync();
            return createdEntity;
        }


        public async Task<bool> EditAsync(int id, SizeEditDto sizeEditDto)
        {
            var sizeEntity = await GetByIdAsync(id);
            _mapper.Map(sizeEditDto, sizeEntity);
            sizeEntity.UpdatedAt = DateTime.UtcNow.AddHours(4);
            _sizeRepo.Update(sizeEntity);
            await _sizeRepo.SaveChangesAsync();
            return true;
        }


        public async Task<ICollection<Size>> GetAllAsync()
        {
            return await _sizeRepo.GetAllAsync();
        }


        public async Task<Size> GetByIdAsync(int id)
        {
            if (!await _sizeRepo.IsExistsAsync(id))
            {
                throw new EntryPointNotFoundException();
            }
            return await _sizeRepo.GetByIdAsync(id);
        }


        public async Task<bool> SoftDeleteAsync(int id)
        {
            var sizeEntity = await GetByIdAsync(id);
            _sizeRepo.SoftDelete(sizeEntity);
            await _sizeRepo.SaveChangesAsync();
            return true;
        }


        public async Task<bool> UpdateAsync(int id, SizeCreateDto sizeUpdateDto)
        {
            var sizeEntity = await GetByIdAsync(id);
            Size updatedSize = _mapper.Map<Size>(sizeUpdateDto);
            updatedSize.UpdatedAt = DateTime.UtcNow.AddHours(4);
            updatedSize.Id = id;
            _sizeRepo.Update(updatedSize);
            await _sizeRepo.SaveChangesAsync();
            return true;
        }
    }
}
