using L2Synergy.IdentityService.Shared.Dtos.RoleDtos;
using L2Synergy.Shared.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Synergy.IdentityService.Application.Queries.RoleQueries.GetRoles
{
    public class GetRolesQuery : IRequest<Result<RoleDto>>
    {
    }
}
