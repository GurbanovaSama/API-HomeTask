using ECommerceApi.Core.Entities.Base;

namespace ECommerceApi.Core.Entities
{
    public class Order : BaseAuiditableEntity
    {
        public DateTime OrderDate { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
