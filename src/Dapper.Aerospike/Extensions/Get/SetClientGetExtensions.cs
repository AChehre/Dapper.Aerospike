using System;
using System.Threading;
using System.Threading.Tasks;
using Aerospike.Client;

namespace Dapper.Aerospike
{
    public static class SetClientGetExtensions
    {
      public static async Task<TEntity> Get<TEntity>(this ISet<TEntity> set,
                                                       Policy policy,
                                                       TEntity entity,
                                                       CancellationToken token)
        {
            Record r = await set.Client.Get(policy, token, set.Key(entity));

            return set.GetEntity(r);
        }
        public static async Task<TEntity> Get<TEntity>(this ISet<TEntity> set,
                                                       Policy policy,
                                                       TEntity entity)
        {
            Record r = await set.Client.Get(policy, CancellationToken.None, set.Key(entity));

            return set.GetEntity(r);
        }

        public static async Task<TEntity> Get<TEntity>(this ISet<TEntity> set,
                                                       Policy policy,
                                                       object keyValue,
                                                       CancellationToken token)
        {
            Record r = await set.Client.Get(policy, token, set.Key(keyValue));

            return set.GetEntity(r);
        }
        public static async Task<TEntity> Get<TEntity>(this ISet<TEntity> set,
                                                       Policy policy,
                                                       object keyValue)
        {
            Record r = await set.Client.Get(policy, CancellationToken.None, set.Key(keyValue));

            return set.GetEntity(r);
        }


        public static async Task<TEntity> Get<TEntity>(this ISet<TEntity> set,
                                                       Policy policy,
                                                       Guid keyValue,
                                                       CancellationToken token)
        {
            Record r = await set.Client.Get(policy, token, set.Key(keyValue));

            return set.GetEntity(r);
        }

        public static async Task<TEntity> Get<TEntity>(this ISet<TEntity> set,
                                                       Policy policy,
                                                       Guid keyValue)
        {
            Record r = await set.Client.Get(policy, CancellationToken.None, set.Key(keyValue));

            return set.GetEntity(r);
        }

        public static async Task<TEntity> Get<TEntity>(this ISet<TEntity> set,
                                                       Policy policy,
                                                       DateTime keyValue,
                                                       CancellationToken token)
        {
            Record r = await set.Client.Get(policy, token, set.Key(keyValue));

            return set.GetEntity(r);
        }
        public static async Task<TEntity> Get<TEntity>(this ISet<TEntity> set,
                                                       Policy policy,
                                                       DateTime keyValue)
        {
            Record r = await set.Client.Get(policy, CancellationToken.None, set.Key(keyValue));

            return set.GetEntity(r);
        }

    }
}