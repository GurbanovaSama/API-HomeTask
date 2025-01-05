using FinalApiTask.Core.Entities.Base;

using Microsoft.AspNetCore.Identity;

namespace FinalApiTask.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
