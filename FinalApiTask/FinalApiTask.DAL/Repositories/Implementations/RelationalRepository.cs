using FinalApiTask.DAL.DAL;
using FinalApiTask.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FinalApiTask.DAL.Repositories.Implementations
{
    public class RelationalRepository<Tentity> : IRelationalRepository<Tentity> where Tentity : class, new()
    {
        private readonly AppDbContext _context;

        public RelationalRepository(AppDbContext context)
        {
            _context = context;
        }

        DbSet<Tentity> table => _context.Set<Tentity>();

        public async Task<Tentity> CreateAsync(Tentity entity)
        {
            await table.AddAsync(entity);
            return entity;
        }

        public void Delete(Tentity entity)
        {
            table.Remove(entity);
        }

        public async Task<bool> IsExistsAsync(int firstId, int secondId)
        {
            return await table.FindAsync(firstId, secondId) != null;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
