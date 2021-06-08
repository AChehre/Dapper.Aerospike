using System;
using System.Linq;
using System.Linq.Expressions;
using Aerospike.Client;

namespace Dapper.Aerospike
{
    public static class SetExtensions
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


        public static string[] GetBinNames<TEntity>(this ISet<TEntity> aerospikeEntity,
                                                    params Expression<Func<TEntity, object>>[] properties)
        {
            var propertyNames = properties.Select(p => p.GetPropertyName()).ToArray();
            return aerospikeEntity.GetBinNames(propertyNames);
        }

        public static AerospikeProperty[] GetProperties<TEntity>(
        this ISet<TEntity> aerospikeEntity,
        params Expression<Func<TEntity, object>>[] properties)
        {
            var propertyNames = properties.Select(p => p.GetPropertyName()).ToArray();
            return aerospikeEntity.GetProperties(propertyNames);
        }
    }
}