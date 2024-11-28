using L2Synergy.IdentityService.Application.Queries.UserQueries.GetUsers;
using L2Synergy.IdentityService.Application.Queries.UserQueries.GetUserByMemberId;
using L2Synergy.IdentityService.Application.Queries.RoleQueries.GetRoles;
using L2Synergy.IdentityService.Application.Commands.RoleCommands.AssignRole;
using L2Synergy.IdentityService.Application.Commands.RoleCommands.CreateRole;
using L2Synergy.IdentityService.Application.Commands.RoleCommands.UpdateRole;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using L2Synergy.IdentityService.Shared.Dtos.RoleDtos;

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

        [HttpGet("users/{memberId}")]
        public async Task<IActionResult> GetUserByMemberId(string memberId)
        {
            var result = await mediator.Send(new GetUserByMemberIdQuery(memberId));
            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles()
        {
            var result = await mediator.Send(new GetRolesQuery());
            return Ok(result.Values);
        }

        [HttpPost("roles")]
        public async Task<IActionResult> Create([FromBody] CreateRoleDto createRole)
        {
            var result = await mediator.Send(new CreateRoleCommand { CreateRole = createRole });
            return result.IsSuccess ? Ok(result.StatusCode) : BadRequest(result.Errors);
        }

        [HttpPut("roles")]
        public async Task<IActionResult> Update([FromBody] UpdateRoleDto updateRole)
        {
            var result = await mediator.Send(new UpdateRoleCommand(updateRole));
            return result.IsSuccess ? Ok(result.StatusCode) : BadRequest(result.Errors);
        }


        [HttpPut("roles/assign")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleCommand assignRole)
        {
            var result = await mediator.Send(assignRole);
            return result.IsSuccess ? Ok(result.StatusCode) : BadRequest(result.Errors);
        }

    }
}
