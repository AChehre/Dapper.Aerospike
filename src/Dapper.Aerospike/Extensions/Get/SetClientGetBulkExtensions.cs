using System;
using System.Threading;
using System.Threading.Tasks;
using Aerospike.Client;

namespace Dapper.Aerospike
{
    public static class SetClientGetBulkExtensions
    {
        public static async Task<TEntity[]> Get<TEntity>(this ISet<TEntity> set,
                                                             BatchPolicy policy,
                                                             long[] keyValues,
                                                             CancellationToken token)
        {
            var entities = new TEntity[keyValues.Length];

            var records = await set.Client.Get(policy, token, set.Keys(keyValues));
            for (var index = 0; index < records.Length; index++)
            {
                var record = records[index];
                entities[index] = set.GetEntity(record);
            }

            return entities;
        }

        public static async Task<TEntity[]> Get<TEntity>(this ISet<TEntity> set,
                                                             BatchPolicy policy,
                                                             object[] keyValues,
                                                             CancellationToken token)
        {
            var entities = new TEntity[keyValues.Length];

            var records = await set.Client.Get(policy, token, set.Keys(keyValues));
            for (var index = 0; index < records.Length; index++)
            {
                var record = records[index];
                entities[index] = set.GetEntity(record);
            }

            return entities;
        }


        public static async Task<TEntity[]> Get<TEntity>(this ISet<TEntity> set,
                                                             BatchPolicy policy,
                                                             Guid[] keyValues,
                                                             CancellationToken token)
        {
            var entities = new TEntity[keyValues.Length];

            var records = await set.Client.Get(policy, token, set.Keys(keyValues));
            for (var index = 0; index < records.Length; index++)
            {
                var record = records[index];
                entities[index] = set.GetEntity(record);
            }

            return entities;
        }


        public static async Task<TEntity[]> Get<TEntity>(this ISet<TEntity> set,
                                                             BatchPolicy policy,
                                                             DateTime[] keyValues,
                                                             CancellationToken token)
        {
            var entities = new TEntity[keyValues.Length];

            var records = await set.Client.Get(policy, token, set.Keys(keyValues));
            for (var index = 0; index < records.Length; index++)
            {
                var record = records[index];
                entities[index] = set.GetEntity(record);
            }

            return entities;
        }
    }
}