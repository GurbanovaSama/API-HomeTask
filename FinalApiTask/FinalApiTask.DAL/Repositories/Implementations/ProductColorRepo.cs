using FinalApiTask.Core.Entities;
using FinalApiTask.DAL.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FinalApiTask.DAL.Repositories.Implementations
{
    public class ProductColorRepo : RelationalRepository<ProductColor>
    {
        private readonly DbSet<ProductColor> _table;
        public ProductColorRepo(AppDbContext context) : base(context)
        {
            _table = context.Set<ProductColor>();
        }
        public List<ProductColor> GetByProductId(int id)
        {
            return _table.Where(ps => ps.ProductId == id).ToList();
        }

        public List<ProductColor> GetByColorId(int id)
        {
            return _table.Where(ps => ps.ColorId == id).ToList();
        }
    }
}
