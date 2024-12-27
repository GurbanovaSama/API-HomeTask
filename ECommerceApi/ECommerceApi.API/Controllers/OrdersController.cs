using ECommerceApi.BL.DTOs.OrderDtos;
using ECommerceApi.BL.DTOs.OrderItemDtos;
using ECommerceApi.BL.Services.Implementations;
using ECommerceApi.Core.Entities;
using ECommerceApi.DAL.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IOrderService _orderService;


        public OrdersController(AppDbContext context, IOrderService orderService)
        {
            _context = context;
            _orderService = orderService;
        }




        [HttpGet]
        public async Task<ICollection<Order>> GetAll()
        {
            return await _orderService.GetALLAsync();
        }


        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            return StatusCode(StatusCodes.Status201Created, await _orderService.CreateAsync(createDto));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _orderService.GetByIdAsync(id));
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
                return StatusCode(StatusCodes.Status200OK, await _orderService.SoftDeleteAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }



        [HttpPut("updateorder/{id}")]
        public async Task<IActionResult> Update(int id, OrderCreateDto orderUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _orderService.UpdateAsync(id, orderUpdateDto));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is OrdersController controller &&
                   EqualityComparer<AppDbContext>.Default.Equals(_context, controller._context);
        }





    }
}
