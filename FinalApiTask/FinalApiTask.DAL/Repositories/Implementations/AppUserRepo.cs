using FinalApiTask.Core.Entities;
using FinalApiTask.DAL.DAL;
using FinalApiTask.DAL.Repositories.Abstractions;

namespace FinalApiTask.DAL.Repositories.Implementations
{
    public class AppUserRepo : GenericRepository<AppUser>, IAppUserRepo
    {
        public AppUserRepo(AppDbContext context) : base(context) { }
    }
}
