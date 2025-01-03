using FinalApiTask.Core.Entities.Base;

namespace FinalApiTask.Core.Entities
{
    public class Size : BaseAuiditableEntity
    {
        public string Name { get; set; }
        public ICollection<ProductSize>? ProductSizes { get; set; } 
    }
}
