using WorkShopManagement.BL.Services.Abstractions;
using WorkShopManagement.Core.Entities;
using WorkShopManagement.DAL.Repositories.Abstractions;

namespace WorkShopManagement.BL.Services.Implementations
{
    public class WorkShopService : IWorkShopService
    {
        private readonly IWorkShopRepository _workShopRepo;

        public WorkShopService(IWorkShopRepository workShopRepo)
        {
            _workShopRepo = workShopRepo;
        }

        public async Task<ICollection<WorkShop>> GetALLAsync()
        {
            return await _workShopRepo.GetAllAsync();   
        }
    }
}
