using WorkShopManagement.BL.DTOs.ParticipantDtos;
using WorkShopManagement.BL.DTOs.WorkShopDtos;
using WorkShopManagement.Core.Entities;

namespace WorkShopManagement.BL.Services.Abstractions
{
    public interface IWorkShopService
    {
        Task<ICollection<WorkShop>> GetALLAsync();
        Task<WorkShop> CreateAsync(WorkShopCreateDto entityDto);
        Task<WorkShop> GetByIdAsync(int id);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> UpdateAsync(int id, WorkShopCreateDto entityDto);
    }
}
