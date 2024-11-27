using L2Synergy.IdentityService.Shared.Dtos.UserDtos;
using L2Synergy.Shared.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Synergy.IdentityService.Application.Queries.UserQueries.GetUserByMemberId
{
    public class GetUserByMemberIdQuery : IRequest<IResult<UserDto>>
    {
        public GetUserByMemberIdQuery(string memberId)
        {
            MemberId = memberId;
        }

        public string MemberId { get; set; }

    }
}
