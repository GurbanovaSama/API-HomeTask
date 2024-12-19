using RepositoryPatternTask.Core.Entities.Base;
using RepositoryPatternTask.DAL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternTask.DAL.Repositories.Abstractions
{
    public interface IGenericRepository<Tentity> where Tentity : BaseEntity, new()  
    {
        Task<ICollection<Tentity>> GetAllAsync();
        Task<Tentity> GetByIdAsync(int Id); 
        Task<Tentity> CreateAsync (Tentity entity);     
        void Update(Tentity entity);       
        void Delete(Tentity entity);  
        Task<int> SaveChangesAsync();

    }
}
