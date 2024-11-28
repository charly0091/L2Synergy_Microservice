using L2Synergy.IdentityService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace L2Synergy.IdentityService.Infrastructure.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task CreateAsync(User user, CancellationToken cancellationToken = default(CancellationToken));
        Task Update(User user, CancellationToken cancellationToken = default(CancellationToken));
        Task<User> GetAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken));
        Task<List<User>> GetAllAsync(Expression<Func<User, bool>> predicate = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
