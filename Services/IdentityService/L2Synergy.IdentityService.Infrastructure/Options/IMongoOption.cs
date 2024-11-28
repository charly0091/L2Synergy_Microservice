using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Synergy.IdentityService.Infrastructure.Options
{
    public interface IMongoOption
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

}
