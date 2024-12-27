using ECommerceApi.BL.DTOs.ProductDtos;
using ECommerceApi.BL.Services.Implementations;
using ECommerceApi.Core.Entities;
using ECommerceApi.DAL.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IProductService _productService;

        public ProductsController(AppDbContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        [HttpGet]
        public async Task<ICollection<Product>> GetAll()
        {
            return await _productService.GetALLAsync();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            return StatusCode(StatusCodes.Status201Created, await _productService.CreateAsync(createDto));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _productService.GetByIdAsync(id));
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
                return StatusCode(StatusCodes.Status200OK, await _productService.SoftDeleteAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }



        [HttpPut("updateproduct/{id}")]
        public async Task<IActionResult> Update(int id, ProductCreateDto productUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _productService.UpdateAsync(id, productUpdateDto));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is ProductsController controller &&
                   EqualityComparer<AppDbContext>.Default.Equals(_context, controller._context);
        }



    }
}
