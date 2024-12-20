using WorkShopManagement.Core.Entities;

namespace WorkShopManagement.BL.Services.Abstractions
{
    public interface IWorkShopService
    {
        Task<ICollection<WorkShop>> GetALLAsync();
    }
}
