using L2Synergy.IdentityService.Domain.Models;
using L2Synergy.IdentityService.Infrastructure.Options;
using L2Synergy.IdentityService.Infrastructure.Repositories.Contracts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace L2Synergy.IdentityService.Infrastructure.Repositories.Implementations
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(IMongoOption mongoOption) : base(mongoOption)
        {
        }

        public async Task CreateAsync(Role role, CancellationToken cancellationToken = default) => await _collection.InsertOneAsync(role);

        public async Task<IList<Role>> GetAllAsync(Expression<Func<Role, bool>> predicate = null, CancellationToken cancellationToken = default)
        {
            return predicate is null ? await _collection.Find(_ => true).ToListAsync(cancellationToken)
                                     : await _collection.Find(predicate).ToListAsync(cancellationToken);
        }

        public async Task<Role> GetAsync(Expression<Func<Role, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _collection.Find(predicate).SingleOrDefaultAsync(cancellationToken);
        }

        public async Task Update(Role role, CancellationToken cancellationToken = default) => await _collection.FindOneAndReplaceAsync<Role>(_ => _.Id.Equals(role.Id), role, cancellationToken: cancellationToken);

    }

}
