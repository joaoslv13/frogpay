using FrogPay.Application.DTOs.Auth;
using FrogPay.Application.DTOs.Pessoa;
using FrogPay.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FrogPay.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody] LoginRequest loginRequest, CancellationToken cancellationToken)
        {
            var token = await _authService.LoginAsync(loginRequest, cancellationToken);
            return Ok(token);
        }

    }
}
