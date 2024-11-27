using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace L2Synergy.IdentityService.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [Authorize(Roles = "manager")]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await mediator.Send(new GetUsersQuery());
            return Ok(result.Values);
        }
    }
}
