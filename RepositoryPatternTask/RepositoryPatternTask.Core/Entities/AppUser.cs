using Microsoft.AspNetCore.Identity;

namespace RepositoryPatternTask.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
