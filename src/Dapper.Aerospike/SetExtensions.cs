using System;
using System.Linq;
using System.Linq.Expressions;
using Aerospike.Client;

namespace Dapper.Aerospike
{
    public static class SetExtensions
    {
        public static Key Key<TEntity>(this Set<TEntity> aerospikeEntity, TEntity entity)
        {
          return aerospikeEntity.AerospikeKey.GetKey(entity);
        }

        public static string[] GetBinNames<TEntity>(this Set<TEntity> aerospikeEntity,
                                                    params Expression<Func<TEntity, object>>[] properties)
        {
            var propertyNames = properties.Select(p => p.GetPropertyName()).ToArray();
            return aerospikeEntity.GetBinNames(propertyNames);
        }

        public static AerospikeProperty[] GetProperties<TEntity>(
        this Set<TEntity> aerospikeEntity,
        params Expression<Func<TEntity, object>>[] properties)
        {
            var propertyNames = properties.Select(p => p.GetPropertyName()).ToArray();
            return aerospikeEntity.GetProperties(propertyNames);
        }
    }
}