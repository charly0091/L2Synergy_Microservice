using L2Synergy.IdentityService.Shared.Dtos.UserDtos;
using L2Synergy.Shared.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Synergy.IdentityService.Application.Queries.UserQueries.LoginUser
{
    public class LoginUserQuery : IRequest<Result<TokenDto>>
    {
        public LoginDto Login { get; set; }

    }
}
