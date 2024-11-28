using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Synergy.IdentityService.Application.TokenService.Options
{
    public interface ITokenOption
    {
        string Audience { get; set; }
        string Issuer { get; set; }
        string Key { get; set; }
    }
}
