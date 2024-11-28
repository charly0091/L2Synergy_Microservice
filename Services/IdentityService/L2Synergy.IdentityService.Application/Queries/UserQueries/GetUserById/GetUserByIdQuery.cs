using L2Synergy.IdentityService.Shared.Dtos.UserDtos;
using L2Synergy.Shared.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Synergy.IdentityService.Application.Queries.UserQueries.GetUserById
{
    public class GetUserByIdQuery : IRequest<IResult<UserDto>>
    {
        public GetUserByIdQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }

}
