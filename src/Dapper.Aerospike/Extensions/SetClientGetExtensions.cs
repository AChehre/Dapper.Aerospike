using System.Threading;
using System.Threading.Tasks;
using Aerospike.Client;

namespace Dapper.Aerospike
{
    public static class SetClientGetExtensions
    {
        public static async Task<TEntity> Get<TEntity>(this Set<TEntity> set, TEntity entity, CancellationToken token)
        {
            Record r = await set.Client.Get(new BatchPolicy(), token, set.Key(entity));

            return set.GetEntity(r);
        }

        public static async Task<TEntity> Get<TEntity>(this Set<TEntity> set,
                                                       BatchPolicy policy,
                                                       TEntity entity,
                                                       CancellationToken token)
        {
            Record r = await set.Client.Get(policy, token, set.Key(entity));

            return set.GetEntity(r);
        }

        public static async Task<TEntity> Get<TEntity>(this Set<TEntity> set,
                                                       Policy policy,
                                                       TEntity entity,
                                                       CancellationToken token)
        {
            Record r = await set.Client.Get(policy, token, set.Key(entity));

            return set.GetEntity(r);
        }
    }
}