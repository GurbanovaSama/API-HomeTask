using FinalApiTask.Core.Entities.Base;

namespace FinalApiTask.Core.Entities
{
    public class Category : BaseAuiditableEntity
    {
        public string Name { get; set; }
        public ICollection<Product>? Products { get; set; }  

    }
}
