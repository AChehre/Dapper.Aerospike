using System;
using Aerospike.Client;

namespace Dapper.Aerospike
{
    public static class SetClientTruncateExtensions
    {
        public static void Truncate<TEntity>(this ISet<TEntity> set, DateTime? beforeLastUpdate = null)
        {
            set.Client.Truncate(new InfoPolicy(), set.Namespace, set.Name, beforeLastUpdate);
        }

        public static void Truncate<TEntity>(this ISet<TEntity> set,
                                             InfoPolicy writePolicy,
                                             DateTime? beforeLastUpdate = null)
        {
            set.Client.Truncate(writePolicy, set.Namespace, set.Name, beforeLastUpdate);
        }
    }
}