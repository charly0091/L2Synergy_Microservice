using L2Synergy.IdentityService.Shared.Dtos.UserDtos;
using L2Synergy.Shared.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Synergy.IdentityService.Application.Queries.UserQueries.GetUserByRefreshToken
{
    public class GetUserByRefreshTokenQuery : IRequest<IResult<TokenDto>>
    {
        public GetUserByRefreshTokenQuery(string refreshToken)
        {
            RefreshToken = refreshToken;
        }

        public string RefreshToken { get; set; }
    }

}
