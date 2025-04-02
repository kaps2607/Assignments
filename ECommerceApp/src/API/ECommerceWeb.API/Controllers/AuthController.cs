using ECommerceWeb.Application.Interfaces.Identity;
using ECommerceWeb.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest authRequest)
        {
            var response = await _authService.Login(authRequest);
            return Ok(response);
        }
        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            var response = await _authService.Register(request);
            return Ok(response);
        }
    }
}
