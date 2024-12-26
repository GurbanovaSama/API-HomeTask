using RepositoryPatternTask.Core.Entities;

namespace RepositoryPatternTask.BL.ExternalServices.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(AppUser appUser);
    }
}
