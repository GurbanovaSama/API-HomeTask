using AutoMapper;
using FinalApiTask.BL.DTOs.ProductColorDtos;
using FinalApiTask.BL.Services.Abstractions;
using FinalApiTask.Core.Entities;
using FinalApiTask.DAL.Repositories.Abstractions;
using FinalApiTask.DAL.Repositories.Implementations;

namespace FinalApiTask.BL.Services.Implementations;

public class ProductColorService : IProductColorRepo
{
    private readonly IProductColorRepo _productColorRepo;

    public ProductColorService(IProductColorRepo productColorRepo)
    {
        _productColorRepo = productColorRepo;
    }

    public async Task<ProductColor> CreateAsync(ProductColor entity)
    {
        await _productColorRepo.CreateAsync(entity);
        await _productColorRepo.SaveChangesAsync();
        return entity;
    }

    public void Delete(ProductColor entity)
    {
        _productColorRepo.Delete(entity);
        _productColorRepo.SaveChangesAsync().Wait();
    }

    public async Task<bool> IsExistsAsync(int firstId, int secondId)
    {
        return await _productColorRepo.IsExistsAsync(firstId, secondId);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _productColorRepo.SaveChangesAsync();
    }
}
