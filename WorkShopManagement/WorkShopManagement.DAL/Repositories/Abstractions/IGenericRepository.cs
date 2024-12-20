using WorkShopManagement.Core.Entities.Base;

namespace WorkShopManagement.DAL.Repositories.Abstractions
{
    public interface IGenericRepository<Tentity> where Tentity : BaseEntity, new()  
    {
        Task<ICollection<Tentity>> GetAllAsync();
        Task<Tentity> GetByIdAsync(int Id);
        Task<Tentity> CreateAsync(Tentity entity);  
        void Update(Tentity entity);        
        void Delete(Tentity entity);        
        Task<int> SaveChangeAsync();  
    }
}
