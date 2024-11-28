using L2Synergy.IdentityService.Shared.Dtos.RoleDtos;
using L2Synergy.Shared.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Synergy.IdentityService.Application.Commands.RoleCommands.CreateRole
{
    public class CreateRoleCommand : IRequest<Result>
    {
        public CreateRoleDto CreateRole { get; set; }
    }
}
