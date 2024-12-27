using AutoMapper;
using ECommerceApi.BL.DTOs.OrderItemDtos;
using ECommerceApi.BL.DTOs.ProductDtos;
using ECommerceApi.BL.Exceptions.CommonExceptions;
using ECommerceApi.BL.Services.Implementations;
using ECommerceApi.Core.Entities;
using ECommerceApi.DAL.Repositories.Abstractions;

namespace ECommerceApi.BL.Services.Abstractions
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepo;

        private readonly IMapper _mapper;

        public OrderItemService(IOrderItemRepository orderItemRepo, IMapper mapper)
        {
            _orderItemRepo = orderItemRepo;
            _mapper = mapper;
        }



        public async Task<OrderItem> CreateAsync(OrderItemCreateDto entityDto)
        {
            OrderItem createdOrderItem = _mapper.Map<OrderItem>(entityDto);
            createdOrderItem.CreatedAt = DateTime.UtcNow.AddHours(4);
            var createdEntity = await _orderItemRepo.CreateAsync(createdOrderItem);
            await _orderItemRepo.SaveChangesAsync();
            return createdEntity;
        }

        public async Task<ICollection<OrderItem>> GetALLAsync()
        {
            return await _orderItemRepo.GetAllAsync();
        }

        public async Task<OrderItem> GetByIdAsync(int id)
        {
            if (!await _orderItemRepo.IsExistsAsync(id))
            {
                throw new EntityNotFoundException();
            }
            return await _orderItemRepo.GetByIdAsync(id);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var orderItemEntity = await GetByIdAsync(id);
            _orderItemRepo.SoftDelete(orderItemEntity);
            await _orderItemRepo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, OrderItemCreateDto orderItemUpdateDto)
        {
            var orderItemEntity = await GetByIdAsync(id);
            OrderItem updatedOrderItem = _mapper.Map<OrderItem>(orderItemUpdateDto);
            updatedOrderItem.UpdatedAt = DateTime.UtcNow.AddHours(4);
            updatedOrderItem.Id = id;
            _orderItemRepo.Update(updatedOrderItem);
            await _orderItemRepo.SaveChangesAsync();
            return true;
        }
    }
}
