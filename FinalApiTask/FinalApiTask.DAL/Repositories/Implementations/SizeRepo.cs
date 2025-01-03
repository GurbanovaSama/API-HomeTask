using FinalApiTask.Core.Entities;
using FinalApiTask.DAL.DAL;
using FinalApiTask.DAL.Repositories.Abstractions;
using System.Drawing;

namespace FinalApiTask.DAL.Repositories.Implementations
{
    public class SizeRepo : GenericRepository<Core.Entities.Size>, ISizeRepo
    {
        public SizeRepo(AppDbContext context) : base(context)
        {
        }
    }
}
