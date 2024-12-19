using Microsoft.EntityFrameworkCore;
using WorkShopManagement.Core.Entities.Base;
using WorkShopManagement.DAL.DAL;
using WorkShopManagement.DAL.Repositories.Abstractions;

namespace WorkShopManagement.DAL.Repositories.Implementations
{
    public class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : BaseEntity, new()
    {

        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        DbSet<Tentity> table => _context.Set<Tentity>();


        public async Task<ICollection<Tentity>> GetAllAsync()
        {
            return await table.ToListAsync();   
        }

        public async Task<Tentity> CreateAsync(Tentity entity)
        {
            await table.AddAsync(entity);
            return entity;  
        }

        public async Task<Tentity> GetByIdAsync(int Id)
        {
           return await table.FirstOrDefaultAsync(x => x.Id == Id);     
        }

        public void Update(Tentity entity)
        {
            table.Update(entity);
        }

        public void Delete(Tentity entity)
        {
            table.Remove(entity);
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();   
        }

      
    }

}
