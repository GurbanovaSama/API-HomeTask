using FinalApiTask.Core.Entities;
using FinalApiTask.DAL.DAL;
using FinalApiTask.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FinalApiTask.DAL.Repositories.Implementations
{
    public class ProductSizeRepo : RelationalRepository<ProductSize>
    {
        private readonly DbSet<ProductSize> _table;

        public ProductSizeRepo(AppDbContext context) : base(context)
        {
            _table = context.Set<ProductSize>();    
        }

        public List<ProductSize> GetByProductId(int id)
        {
            return _table.Where(ps => ps.ProductId == id).ToList();
        }

        public List<ProductSize> GetBySizeId(int id)
        {
            return _table.Where(ps => ps.SizeId == id).ToList();
        }
    }
}
