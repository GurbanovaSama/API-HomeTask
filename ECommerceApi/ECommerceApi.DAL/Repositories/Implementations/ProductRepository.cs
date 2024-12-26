using ECommerceApi.Core.Entities;
using ECommerceApi.DAL.DAL;
using ECommerceApi.DAL.Repositories.Abstractions;

namespace ECommerceApi.DAL.Repositories.Implementations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}

