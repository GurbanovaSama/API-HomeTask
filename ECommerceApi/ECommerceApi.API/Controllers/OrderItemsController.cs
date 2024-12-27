using ECommerceApi.BL.DTOs.OrderItemDtos;
using ECommerceApi.BL.DTOs.ProductDtos;
using ECommerceApi.BL.Services.Abstractions;
using ECommerceApi.BL.Services.Implementations;
using ECommerceApi.Core.Entities;
using ECommerceApi.DAL.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IOrderItemService _orderItemService;
        public OrderItemsController(AppDbContext context, IOrderItemService orderItemService)
        {
            _context = context;
            _orderItemService = orderItemService;
        }


        [HttpGet]
        public async Task<ICollection<OrderItem>> GetAll()
        {
            return await _orderItemService.GetALLAsync();
        }


        [HttpPost]
        public async Task<IActionResult> Create(OrderItemCreateDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            return StatusCode(StatusCodes.Status201Created, await _orderItemService.CreateAsync(createDto));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _orderItemService.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _orderItemService.SoftDeleteAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }



        [HttpPut("updateorderItem/{id}")]
        public async Task<IActionResult> Update(int id, OrderItemCreateDto orderItemUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _orderItemService.UpdateAsync(id, orderItemUpdateDto));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is OrderItemsController controller &&
                   EqualityComparer<AppDbContext>.Default.Equals(_context, controller._context);
        }



    }
}
