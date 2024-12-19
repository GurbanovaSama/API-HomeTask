using Microsoft.EntityFrameworkCore;
using RepositoryPatternTask.Core.Entities.Base;
using RepositoryPatternTask.DAL.DAL;
using RepositoryPatternTask.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternTask.DAL.Repositories.Implementations
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

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
