using AutoMapper;
using FinalApiTask.BL.DTOs.ProductSizeDtos;
using FinalApiTask.BL.Services.Abstractions;
using FinalApiTask.Core.Entities;
using FinalApiTask.DAL.Repositories.Abstractions;
using FinalApiTask.DAL.Repositories.Implementations;

namespace FinalApiTask.BL.Services.Implementations
{
    public class ProductSizeService : IProductSizeRepo
    {
        private readonly IProductSizeRepo _productSizeRepo;

        public ProductSizeService(IProductSizeRepo productSizeRepo)
        {
            _productSizeRepo = productSizeRepo;
        }

        public async Task<ProductSize> CreateAsync(ProductSize entity)
        {
            await _productSizeRepo.CreateAsync(entity);
            await _productSizeRepo.SaveChangesAsync();
            return entity;
        }

        public void Delete(ProductSize entity)
        {
            _productSizeRepo.Delete(entity);
            _productSizeRepo.SaveChangesAsync().Wait();
        }

        public async Task<bool> IsExistsAsync(int firstId, int secondId)
        {
            return await _productSizeRepo.IsExistsAsync(firstId, secondId);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _productSizeRepo.SaveChangesAsync();
        }
    }
}
