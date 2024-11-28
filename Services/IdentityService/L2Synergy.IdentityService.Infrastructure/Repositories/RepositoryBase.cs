using L2Synergy.IdentityService.Infrastructure.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Synergy.IdentityService.Infrastructure.Repositories
{
    public abstract class RepositoryBase<TCollection>
    {
        protected IMongoCollection<TCollection> _collection { get; }

        public RepositoryBase(IMongoOption mongoOption)
        {
            var client = new MongoClient(mongoOption.ConnectionString);
            IMongoDatabase database = client.GetDatabase(mongoOption.DatabaseName);
            _collection = database.GetCollection<TCollection>(typeof(TCollection).Name);
        }

    }

}
