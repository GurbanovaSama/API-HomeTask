using AutoMapper;
using ECommerceApi.BL.DTOs.OrderDtos;
using ECommerceApi.BL.DTOs.ProductDtos;
using ECommerceApi.BL.Exceptions.CommonExceptions;
using ECommerceApi.BL.Services.Implementations;
using ECommerceApi.Core.Entities;
using ECommerceApi.DAL.Repositories.Abstractions;

namespace ECommerceApi.BL.Services.Abstractions
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }

        public async Task<Order> CreateAsync(OrderCreateDto entityDto)
        {
            Order createdOrder = _mapper.Map<Order>(entityDto);
            createdOrder.CreatedAt = DateTime.UtcNow.AddHours(4);
            var createdEntity = await _orderRepo.CreateAsync(createdOrder);
            await _orderRepo.SaveChangesAsync();
            return createdEntity;
        }


        public async Task<ICollection<Order>> GetALLAsync()
        {
            return await _orderRepo.GetAllAsync();
        }


        public async Task<Order> GetByIdAsync(int id)
        {
            if (!await _orderRepo.IsExistsAsync(id))
            {
                throw new EntityNotFoundException();
            }
            return await _orderRepo.GetByIdAsync(id);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var orderEntity = await GetByIdAsync(id);
            _orderRepo.SoftDelete(orderEntity);
            await _orderRepo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, OrderCreateDto orderUpdateDto)
        {
            var orderEntity = await GetByIdAsync(id);
            Order updatedOrder = _mapper.Map<Order>(orderUpdateDto);
            updatedOrder.UpdatedAt = DateTime.UtcNow.AddHours(4);
            updatedOrder.Id = id;
            _orderRepo.Update(updatedOrder);
            await _orderRepo.SaveChangesAsync();
            return true;
        }
    }
}
