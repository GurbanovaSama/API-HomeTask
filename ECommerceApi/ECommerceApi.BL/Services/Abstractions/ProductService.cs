using AutoMapper;
using ECommerceApi.BL.DTOs.ProductDtos;
using ECommerceApi.BL.Exceptions.CommonExceptions;
using ECommerceApi.BL.Services.Implementations;
using ECommerceApi.Core.Entities;
using ECommerceApi.DAL.Repositories.Abstractions;

namespace ECommerceApi.BL.Services.Abstractions
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepo, IMapper mapper)
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


        public async Task<ICollection<Product>> GetALLAsync()
        {
            return await _productRepo.GetAllAsync();    
        }


        public async Task<Product> GetByIdAsync(int id)
        {
            if (!await _productRepo.IsExistsAsync(id))
            {
                throw new EntityNotFoundException();
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
