using FinalApiTask.Core.Entities.Base;

namespace FinalApiTask.Core.Entities
{
    public class AppUser : BaseAuiditableEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
