using L2Synergy.Shared.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Synergy.IdentityService.Application.Queries.UserQueries.LogoutUser
{
    public class LogoutUserQuery : IRequest<Result>
    {
        public LogoutUserQuery(string refreshToken)
        {
            RefreshToken = refreshToken;
        }

        public string RefreshToken { get; set; }
    }

}
