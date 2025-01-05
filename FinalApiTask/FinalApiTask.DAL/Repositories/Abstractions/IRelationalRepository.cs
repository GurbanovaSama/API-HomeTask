namespace FinalApiTask.DAL.Repositories.Abstractions;

public interface IRelationalRepository<Tentity> where Tentity : class, new()
{
    Task<bool> IsExistsAsync(int firstId, int secondId);
    Task<Tentity> CreateAsync(Tentity entity);
    void Delete(Tentity entity);
    Task<int> SaveChangesAsync();
}