using FinalApiTask.Core.Entities;

namespace FinalApiTask.BL.ExternalServices.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(AppUser appUser);
    }
}
