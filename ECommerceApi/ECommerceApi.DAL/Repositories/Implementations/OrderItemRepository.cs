using ECommerceApi.Core.Entities;
using ECommerceApi.DAL.DAL;
using ECommerceApi.DAL.Repositories.Abstractions;

namespace ECommerceApi.DAL.Repositories.Implementations
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(AppDbContext context) : base(context)
        {
        }
    }
}
