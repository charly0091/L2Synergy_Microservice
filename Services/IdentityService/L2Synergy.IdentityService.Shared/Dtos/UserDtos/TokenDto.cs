﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Synergy.IdentityService.Shared.Dtos.UserDtos
{
    public record TokenDto(string Token, DateTimeOffset TokenExpire, string RefreshToken, DateTimeOffset RefreshExpire, UserDto User);

}
