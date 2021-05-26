using System;
using System.Linq;
using System.Linq.Expressions;

namespace Dapper.Aerospike
{
    public static class SetExtensions
    {
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