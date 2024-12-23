using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternTask.BL.DTOs.AppUserDtos;
using RepositoryPatternTask.BL.Services.Abstractions;

namespace RepositoryPatternTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(AppUserCreateDto appUserCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _authService.RegisterAsync(appUserCreateDto));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }



        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var result = await _authService.ConfirmEmailAsync(userId, token);
            if (!result)
            {
                return BadRequest("Email confirmation failed");
            }
            return Ok("Successfully");




        }


        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            var result = await _authService.ChangePasswordAsync(changePasswordDto); 
            if (!result)
            {
                return BadRequest("Password change failed");
            }
            return Ok("Successfully");
        }

    }
}
