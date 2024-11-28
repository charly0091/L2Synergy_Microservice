using L2Synergy.IdentityService.Shared.Dtos.UserDtos;
using L2Synergy.Shared.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Synergy.IdentityService.Application.Commands.UserCommands.RegisterUser
{
    public class RegisterUserCommand : IRequest<Result>
    {
        public RegisterDto Register { get; set; }
    }

}
