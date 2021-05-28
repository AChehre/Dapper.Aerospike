using System;
using System.Threading;
using System.Threading.Tasks;
using Aerospike.Client;

namespace Dapper.Aerospike
{
    public static class SetClientGetExtensions
    {
        public static async Task<TEntity> Get<TEntity>(this Set<TEntity> set,
                                                       DateTime keyValue,
                                                       CancellationToken token)
        {
            return await set.Get(new Policy(), keyValue, token);
        }


        public static async Task<TEntity> Get<TEntity>(this Set<TEntity> set, Guid keyValue, CancellationToken token)
        {
            return await set.Get(new Policy(), keyValue, token);
        }


        public static async Task<TEntity> Get<TEntity>(this Set<TEntity> set, object keyValue, CancellationToken token)
        {
            return await set.Get(new Policy(), keyValue, token);
        }


        public static async Task<TEntity> Get<TEntity>(this Set<TEntity> set, TEntity entity, CancellationToken token)
        {
            return await set.Get(new Policy(), entity, token);
        }


        public static async Task<TEntity> Get<TEntity>(this Set<TEntity> set,
                                                       Policy policy,
                                                       TEntity entity,
                                                       CancellationToken token)
        {
            Record r = await set.Client.Get(policy, token, set.Key(entity));

            return set.GetEntity(r);
        }


        public static async Task<TEntity> Get<TEntity>(this Set<TEntity> set,
                                                       Policy policy,
                                                       object keyValue,
                                                       CancellationToken token)
        {
            Record r = await set.Client.Get(policy, token, set.Key(keyValue));

            return set.GetEntity(r);
        }


        public static async Task<TEntity> Get<TEntity>(this Set<TEntity> set,
                                                       Policy policy,
                                                       Guid keyValue,
                                                       CancellationToken token)
        {
            Record r = await set.Client.Get(policy, token, set.Key(keyValue));

            return set.GetEntity(r);
        }

        public static async Task<TEntity> Get<TEntity>(this Set<TEntity> set,
                                                       Policy policy,
                                                       DateTime keyValue,
                                                       CancellationToken token)
        {
            Record r = await set.Client.Get(policy, token, set.Key(keyValue));

            return set.GetEntity(r);
        }
    }
}