using FinalApiTask.Core.Entities;
using FinalApiTask.DAL.DAL;
using FinalApiTask.DAL.Repositories.Abstractions;

namespace FinalApiTask.DAL.Repositories.Implementations
{
    public class CategoryRepo : GenericRepository<Category>, ICategoryRepo
    {
        public CategoryRepo(AppDbContext context) : base(context)
        {
        }
    }
}
