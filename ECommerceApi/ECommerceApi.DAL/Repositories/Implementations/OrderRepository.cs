using ECommerceApi.Core.Entities;
using ECommerceApi.DAL.DAL;
using ECommerceApi.DAL.Repositories.Abstractions;

namespace ECommerceApi.DAL.Repositories.Implementations
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }
    }
}
