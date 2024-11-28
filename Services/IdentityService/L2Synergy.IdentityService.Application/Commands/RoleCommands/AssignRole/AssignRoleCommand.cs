using L2Synergy.Shared.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Synergy.IdentityService.Application.Commands.RoleCommands.AssignRole
{
    public class AssignRoleCommand : IRequest<Result>
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
}
