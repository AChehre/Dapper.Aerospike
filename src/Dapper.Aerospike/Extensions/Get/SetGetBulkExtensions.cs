using System;
using System.Threading;
using System.Threading.Tasks;
using Aerospike.Client;

namespace Dapper.Aerospike
{
    public static class SetGetBulkExtensions
    {

        public static async Task<TEntity[]> Get<TEntity>(this ISet<TEntity> set,
                                                             BatchPolicy policy,
                                                             long[] keyValues)
        {
            return await set.Get(policy, keyValues, CancellationToken.None);
        }
        public static async Task<TEntity[]> Get<TEntity>(this ISet<TEntity> set,
                                                             long[] keyValues)
        {
            return await set.Get(new BatchPolicy(), keyValues, CancellationToken.None);
        }


        public static async Task<TEntity[]> Get<TEntity>(this ISet<TEntity> set,
                                                         BatchPolicy policy,
                                                         object[] keyValues)
        {
            return await set.Get(policy, keyValues, CancellationToken.None);
        }
        public static async Task<TEntity[]> Get<TEntity>(this ISet<TEntity> set,
                                                             object[] keyValues)
        {
            return await set.Get(new BatchPolicy(), keyValues, CancellationToken.None);
        }

        public static async Task<TEntity[]> Get<TEntity>(this ISet<TEntity> set,
                                                             BatchPolicy policy,
                                                             Guid[] keyValues)
        {
            return await set.Get(policy, keyValues, CancellationToken.None);
        }
        public static async Task<TEntity[]> Get<TEntity>(this ISet<TEntity> set,
                                                             Guid[] keyValues)
        {
            return await set.Get(new BatchPolicy(), keyValues, CancellationToken.None);
        }

        public static async Task<TEntity[]> Get<TEntity>(this ISet<TEntity> set,
                                                             BatchPolicy policy,
                                                             DateTime[] keyValues)
        {
            return await set.Get(policy, keyValues, CancellationToken.None);
        }
        public static async Task<TEntity[]> Get<TEntity>(this ISet<TEntity> set,
                                                             DateTime[] keyValues)
        {
            return await set.Get(new BatchPolicy(), keyValues, CancellationToken.None);
        }
    }
}