using WorkShopManagement.Core.Entities.Base;

namespace WorkShopManagement.Core.Entities
{
    public class Participant : BaseAuiditableEntity
    {
        public string Name { get; set; }    
        public string Email { get; set; }
        public string Phone { get; set; }
        public int WorkShopId { get; set; } 
        public  WorkShop? WorkShop { get; set; } 

    }
}
