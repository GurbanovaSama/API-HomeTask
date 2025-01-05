using FinalApiTask.BL.DTOs.ColorDtos;
using FinalApiTask.BL.DTOs.ProductDtos;
using FinalApiTask.BL.Services.Abstractions;
using FinalApiTask.BL.Services.Implementations;
using FinalApiTask.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalApiTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }



        [HttpGet]
        public async Task<ICollection<Product>> GetAll()
        {
            return await _productService.GetAllAsync();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            };
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
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
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


        [HttpPatch("updateproduct/{id}")]
        public async Task<IActionResult> Edit(int id, ProductEditDto productEditDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _productService.EditAsync(id, productEditDto));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }



        [HttpPost("{id}/upload")]
        public async Task<IActionResult> UploadImage(int id, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Invalid file.");
            }
            var result = await _productService.UploadImageAsync(id, file);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(new { path = result.Path });
        }

    }
}
