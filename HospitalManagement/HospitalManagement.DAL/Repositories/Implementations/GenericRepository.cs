using HospitalManagement.Core.Entities.Base;
using HospitalManagement.DAL.DAL;
using HospitalManagement.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.DAL.Repositories.Implementations
{
    public class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        DbSet<Tentity> table => _context.Set<Tentity>();        


        public async Task<Tentity> CreateAsync(Tentity entity)
        {
            await table.AddAsync(entity);
            return entity;
        }

        public async Task<ICollection<Tentity>> GetAllAsync()
        {
            return await table.Where(x => !x.IsDeleted).ToListAsync();
        }

        public  async Task<Tentity> GetByIdAsync(int Id)
        {
            var entity = await table.FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted);
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<bool> IsExistsAsync(int Id)
        {
            return await table.AnyAsync(x => x.Id == Id && !x.IsDeleted);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void SoftDelete(Tentity entity)
        {
            entity.IsDeleted = true;
        }

        public void Update(Tentity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
