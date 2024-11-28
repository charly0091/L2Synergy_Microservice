using L2Synergy.IdentityService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace L2Synergy.IdentityService.Infrastructure.Repositories.Contracts
{
    public interface IRoleRepository
    {
        Task CreateAsync(Role role, CancellationToken cancellationToken = default(CancellationToken));
        Task Update(Role role, CancellationToken cancellationToken = default(CancellationToken));
        Task<Role> GetAsync(Expression<Func<Role, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken));
        Task<IList<Role>> GetAllAsync(Expression<Func<Role, bool>> predicate = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
