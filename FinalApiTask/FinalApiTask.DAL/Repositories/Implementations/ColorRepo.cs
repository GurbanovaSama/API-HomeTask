using FinalApiTask.Core.Entities;
using FinalApiTask.DAL.DAL;
using FinalApiTask.DAL.Repositories.Abstractions;

namespace FinalApiTask.DAL.Repositories.Implementations;

public class ColorRepo : GenericRepository<Color>, IColorRepo
{
    public ColorRepo(AppDbContext context) : base(context) { }
}
