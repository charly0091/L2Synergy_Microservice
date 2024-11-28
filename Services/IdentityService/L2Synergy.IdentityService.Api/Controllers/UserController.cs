using L2Synergy.IdentityService.Shared.Dtos.UserDtos;
using L2Synergy.IdentityService.Application.Queries.UserQueries.LoginUser;
using L2Synergy.IdentityService.Application.Queries.UserQueries.LogoutUser;
using L2Synergy.IdentityService.Application.Queries.UserQueries.GetUserByRefreshToken;
using L2Synergy.IdentityService.Application.Queries.UserQueries.GetUserById;
using L2Synergy.IdentityService.Application.Commands.UserCommands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace L2Synergy.IdentityService.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController(IMediator _mediator) : ControllerBase
    {


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto register)
        {
            var result = await _mediator.Send(new RegisterUserCommand
            {
                Register = register
            });
            return result.IsSuccess ? Ok(result) : BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            var result = await _mediator.Send(new LoginUserQuery
            {
                Login = login
            });
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Errors);
        }


        [HttpGet("relogin/{refreshToken}")]
        public async Task<IActionResult> Relogin(string refreshToken)
        {
            var user = await _mediator.Send(new GetUserByRefreshTokenQuery(refreshToken));
            return user.IsSuccess ? Ok(user.Value) : NotFound(user.Message);
        }


        [HttpGet("profile/{userId}")]
        public async Task<IActionResult> GetProfile(string userId)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(userId));
            return user.IsSuccess ? Ok(user.Value) : NotFound(user.Message);
        }


        [HttpGet("logout/{refreshToken}")]
        public async Task<IActionResult> Logout(string refreshToken)
        {
            var result = await _mediator.Send(new LogoutUserQuery(refreshToken));
            return result.IsSuccess ? Ok(result.Message) : NotFound();
        }
    }
}
