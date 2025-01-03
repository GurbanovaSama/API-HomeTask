using AutoMapper;
using FinalApiTask.BL.DTOs.ColorDtos;
using FinalApiTask.BL.DTOs.ProductDtos;
using FinalApiTask.BL.Services.Abstractions;
using FinalApiTask.Core.Entities;
using FinalApiTask.DAL.Repositories.Abstractions;
using FinalApiTask.DAL.Repositories.Implementations;

namespace FinalApiTask.BL.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepo productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }



        public async Task<Product> CreateAsync(ProductCreateDto entityDto)
        {
            Product createdProduct = _mapper.Map<Product>(entityDto);
            createdProduct.CreatedAt = DateTime.UtcNow.AddHours(4);
            var createdEntity = await _productRepo.CreateAsync(createdProduct);
            await _productRepo.SaveChangesAsync();
            return createdEntity;
        }


        public async Task<bool> EditAsync(int id, ProductEditDto productEditDto)
        {
            var productEntity = await GetByIdAsync(id);
            _mapper.Map(productEditDto, productEntity);
            productEntity.UpdatedAt = DateTime.UtcNow.AddHours(4);
            _productRepo.Update(productEntity);
            await _productRepo.SaveChangesAsync();
            return true;
        }


        public async Task<ICollection<Product>> GetAllAsync()
        {
            return await _productRepo.GetAllAsync();
        }


        public async Task<Product> GetByIdAsync(int id)
        {
            if (!await _productRepo.IsExistsAsync(id))
            {
                throw new EntryPointNotFoundException();
            }
            return await _productRepo.GetByIdAsync(id);
        }


        public async Task<bool> SoftDeleteAsync(int id)
        {
            var productEntity = await GetByIdAsync(id);
            _productRepo.SoftDelete(productEntity);
            await _productRepo.SaveChangesAsync();
            return true;
        }


        public async Task<bool> UpdateAsync(int id, ProductCreateDto productUpdateDto)
        {
            var productEntity = await GetByIdAsync(id);
            Product updatedProduct = _mapper.Map<Product>(productUpdateDto);
            updatedProduct.UpdatedAt = DateTime.UtcNow.AddHours(4);
            updatedProduct.Id = id;
            _productRepo.Update(updatedProduct);
            await _productRepo.SaveChangesAsync();
            return true;
        }

    }
}
