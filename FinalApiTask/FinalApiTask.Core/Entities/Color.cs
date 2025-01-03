using FinalApiTask.Core.Entities.Base;

namespace FinalApiTask.Core.Entities
{
    public class Color : BaseAuiditableEntity
    {
        public string Name { get; set; }
        public ICollection<ProductColor>? ProductColors { get; set; }   
    }
}
