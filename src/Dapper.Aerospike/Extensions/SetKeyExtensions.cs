using System;
using Aerospike.Client;

namespace Dapper.Aerospike
{
    public static class SetKeyExtensions
    {
        public static Key Key<TEntity>(this ISet<TEntity> aerospikeEntity, TEntity entity)
        {
            return aerospikeEntity.AerospikeKey.GetKey(entity);
        }

        public static Key Key<TEntity>(this ISet<TEntity> aerospikeEntity, Guid keyValue)
        {
            return aerospikeEntity.AerospikeKey.GetKey(keyValue);
        }

        public static Key Key<TEntity>(this ISet<TEntity> aerospikeEntity, DateTime keyValue)
        {
            return aerospikeEntity.AerospikeKey.GetKey(keyValue);
        }

        public static Key Key<TEntity>(this ISet<TEntity> aerospikeEntity, object keyValue)
        {
            return aerospikeEntity.AerospikeKey.GetKey(keyValue);
        }

        public static Key[] Keys<TEntity>(this ISet<TEntity> aerospikeEntity, Guid[] keyValues)
        {
            return aerospikeEntity.AerospikeKey.GetKeys(keyValues);
        }

        public static Key[] Keys<TEntity>(this ISet<TEntity> aerospikeEntity, DateTime[] keyValues)
        {
            return aerospikeEntity.AerospikeKey.GetKeys(keyValues);
        }

        public static Key[] Keys<TEntity>(this ISet<TEntity> aerospikeEntity, object[] keyValues)
        {
            return aerospikeEntity.AerospikeKey.GetKeys(keyValues);
        }
        public static Key[] Keys<TEntity>(this ISet<TEntity> aerospikeEntity, long[] keyValues)
        {
            return aerospikeEntity.AerospikeKey.GetKeys(keyValues);
        }

    }
}