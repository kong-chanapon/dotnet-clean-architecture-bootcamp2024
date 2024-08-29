using Application.Features.Auth.Commands;
using Application.Features.Auth.Commands.Login;
using Application.Models.Auth;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto reqeust)
        {
            var result = await _mediator.Send(new RegisterCommand(reqeust));
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto reqeust)
        {
            var result = await _mediator.Send(new LoginCommand(reqeust));
            return Ok(result);
        }
    }
}
