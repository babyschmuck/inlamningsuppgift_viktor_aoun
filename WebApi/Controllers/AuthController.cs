using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Filters;
using WebApi.Models.DTO;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UseApiKey]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register(AuthRegisterModel model)
        {

            if (ModelState.IsValid)
            {

                if (await _authService.RegisterAsync(model))
                {
                    return Created("", null);
                }

            }

            return BadRequest();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(AuthLoginModel model)
        {

            if (ModelState.IsValid)
            {
                var token = await _authService.LoginAsync(model);
                if (!string.IsNullOrEmpty(token))
                {
                    return Ok(token);
                }

            }

            return Unauthorized("Incorrect email or password");
        }
    }
}
