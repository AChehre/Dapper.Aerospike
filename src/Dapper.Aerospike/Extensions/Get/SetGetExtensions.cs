using System;
using System.Threading;
using System.Threading.Tasks;
using Aerospike.Client;

namespace Dapper.Aerospike
{
    public static class SetGetExtensions
    {
        public static async Task<TEntity> Get<TEntity>(this ISet<TEntity> set,
                                                       DateTime[] keyValues,
                                                       CancellationToken token)
        {
            return await set.Get(new Policy(), keyValues, token);
        }
        public static async Task<TEntity> Get<TEntity>(this ISet<TEntity> set,
                                                       DateTime[] keyValues)
        {
            return await set.Get(new Policy(), keyValues);
        }
        public static async Task<TEntity> Get<TEntity>(this ISet<TEntity> set,
                                                       DateTime keyValue,
                                                       CancellationToken token)
        {
            return await set.Get(new Policy(), keyValue, token);
        }
        public static async Task<TEntity> Get<TEntity>(this ISet<TEntity> set,
                                                       DateTime keyValue)
        {
            return await set.Get(new Policy(), keyValue);
        }

        public static async Task<TEntity> Get<TEntity>(this ISet<TEntity> set, Guid keyValue, CancellationToken token)
        {
            return await set.Get(new Policy(), keyValue, token);
        }
        public static async Task<TEntity> Get<TEntity>(this ISet<TEntity> set, Guid keyValue)
        {
            return await set.Get(new Policy(), keyValue);
        }

        public static async Task<TEntity> Get<TEntity>(this ISet<TEntity> set, object keyValue, CancellationToken token)
        {
            return await set.Get(new Policy(), keyValue, token);
        }
        public static async Task<TEntity> Get<TEntity>(this ISet<TEntity> set, object keyValue)
        {
            return await set.Get(new Policy(), keyValue);
        }


        public static async Task<TEntity> Get<TEntity>(this ISet<TEntity> set, TEntity entity, CancellationToken token)
        {
            return await set.Get(new Policy(), entity, token);
        }
        public static async Task<TEntity> Get<TEntity>(this ISet<TEntity> set, TEntity entity)
        {
            return await set.Get(new Policy(), entity);
        }
    }
}