using L2Synergy.IdentityService.Shared.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L2Synergy.IdentityService.Domain.Models;

namespace L2Synergy.IdentityService.Application.TokenService
{
    public interface ITokenGenerator
    {
        TokenDto GenerateToken(User user);
    }
}
