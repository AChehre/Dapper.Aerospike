using System.Collections.Generic;
using System.Threading.Tasks;
using Aerospike.Client;

namespace Dapper.Aerospike
{
    public static class SetQueryExtensions
    {
        public static Task<List<TEntity>> Query<TEntity>(this ISet<TEntity> set)
        {
            return set.Query(new QueryPolicy());
        }
        public static Task<List<TEntity>> Query<TEntity>(this ISet<TEntity> set,
                                                         Statement statement)
        {
            return set.Query(new QueryPolicy(), statement);
        }
    }
}