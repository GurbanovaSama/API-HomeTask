using AutoMapper;
using FinalApiTask.BL.DTOs.ColorDtos;
using FinalApiTask.BL.Services.Abstractions;
using FinalApiTask.Core.Entities;
using FinalApiTask.DAL.Repositories.Abstractions;
using FinalApiTask.DAL.Repositories.Implementations;

namespace FinalApiTask.BL.Services.Implementations
{
    public class ColorService : IColorService
    {
        private readonly IColorRepo _colorRepo;
        private readonly IMapper _mapper;
        public ColorService(IColorRepo colorRepo, IMapper mapper)
        {
            _colorRepo = colorRepo;
            _mapper = mapper;
        }


        public async Task<Color> CreateAsync(ColorCreateDto entityDto)
        {
            Color createdColor = _mapper.Map<Color>(entityDto);
            createdColor.CreatedAt = DateTime.UtcNow.AddHours(4);
            var createdEntity = await _colorRepo.CreateAsync(createdColor);
            await _colorRepo.SaveChangesAsync();
            return createdEntity;
        }


        public async Task<bool> EditAsync(int id, ColorEditDto colorEditDto)
        {
            var colorEntity = await GetByIdAsync(id);
            _mapper.Map(colorEditDto, colorEntity);
            colorEntity.UpdatedAt = DateTime.UtcNow.AddHours(4);
            _colorRepo.Update(colorEntity);
            await _colorRepo.SaveChangesAsync();
            return true;
        }


        public async Task<ICollection<Color>> GetAllAsync()
        {
            return await _colorRepo.GetAllAsync();
        }


        public async Task<Color> GetByIdAsync(int id)
        {
            if (!await _colorRepo.IsExistsAsync(id))
            {
                throw new EntryPointNotFoundException();
            }
            return await _colorRepo.GetByIdAsync(id);
        }


        public async Task<bool> SoftDeleteAsync(int id)
        {
            var colorEntity = await GetByIdAsync(id);
            _colorRepo.SoftDelete(colorEntity);
            await _colorRepo.SaveChangesAsync();
            return true;
        }


        public async Task<bool> UpdateAsync(int id, ColorCreateDto colorUpdateDto)
        {
            var colorEntity = await GetByIdAsync(id);
            Color updatedColor = _mapper.Map<Color>(colorUpdateDto);
            updatedColor.UpdatedAt = DateTime.UtcNow.AddHours(4);
            updatedColor.Id = id;
            _colorRepo.Update(updatedColor);
            await _colorRepo.SaveChangesAsync();
            return true;
        }
    }
}
