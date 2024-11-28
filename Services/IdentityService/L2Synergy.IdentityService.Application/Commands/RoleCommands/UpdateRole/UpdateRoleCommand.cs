using L2Synergy.IdentityService.Shared.Dtos.RoleDtos;
using L2Synergy.Shared.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Synergy.IdentityService.Application.Commands.RoleCommands.UpdateRole
{
    public class UpdateRoleCommand : IRequest<Result>
    {
        public UpdateRoleCommand(UpdateRoleDto updateRole)
        {
            UpdateRole = updateRole;
        }

        public UpdateRoleDto UpdateRole { get; set; }
    }
}
