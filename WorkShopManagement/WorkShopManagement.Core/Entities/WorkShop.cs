using WorkShopManagement.Core.Entities.Base;

namespace WorkShopManagement.Core.Entities
{
    public class WorkShop : BaseAuiditableEntity
    {
        public string Title { get; set; }   
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }    
        public ICollection<Participant>? Participants { get; set; }  
    }
}
