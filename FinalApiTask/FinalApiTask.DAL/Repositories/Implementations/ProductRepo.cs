using FinalApiTask.Core.Entities;
using FinalApiTask.DAL.DAL;
using FinalApiTask.DAL.Repositories.Abstractions;

namespace FinalApiTask.DAL.Repositories.Implementations
{
    public class ProductRepo : GenericRepository<Product>, IProductRepo
    {
        public ProductRepo(AppDbContext context) : base(context)
        {
        } 
    }
}
