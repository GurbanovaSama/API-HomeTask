using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternTask.BL.DTOs.AppUserDtos;
using RepositoryPatternTask.Core.Entities;
using RepositoryPatternTask.DAL.DAL;

namespace RepositoryPatternTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AppUserController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost("create user")]
        public async Task<IActionResult> CreateAppUser([FromBody] AppUserCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  
            }
            var user = new AppUser
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber
            };

            _context.Users.Add(user);   
            await _context.SaveChangesAsync();  
            return Ok(new {message = "User created successfully", userId = user.Id});   
     

        }



        [HttpPost("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.Users
                .Select(u => new
                {
                    u.FirstName, 
                    u.LastName, 
                    u.Email,
                    u.PhoneNumber
                })
                .ToListAsync(); 

            return Ok(users);   
        }




        [HttpGet("getOneUser/{id}")]
        public async Task<IActionResult> GetOneUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }
            return Ok(user);    
        }

    }
}
