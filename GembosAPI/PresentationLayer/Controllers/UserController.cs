using GembosAPI.BusinessLayer.ServiceInterfaces;
using GembosAPI.EntityLayer.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GembosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            try
            {
                var token = await _userService.LoginAsync(loginDTO);

                if (token == null)
                {
                    return Unauthorized();
                }
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            var newUser = await _userService.RegisterAsync(registerDTO);

            if(newUser == null)
            {
                var errorResponse = new
                {
                    Code = 5001,
                    Message = "An unexpected error has occured.",
                };
                return BadRequest(errorResponse);
            }

            return Ok(newUser);
        }
    }
}
