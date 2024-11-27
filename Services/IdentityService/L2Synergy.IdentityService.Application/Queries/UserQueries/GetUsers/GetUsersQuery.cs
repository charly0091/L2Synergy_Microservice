using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using L2Synergy.IdentityService.Shared.Dtos.UserDtos;
using L2Synergy.Shared.Results;

namespace L2Synergy.IdentityService.Application.Queries.UserQueries.GetUsers
{
    public class GetUsersQuery : IRequest<Result<UserDto>>
    {

    }
}
