using System.Collections.Generic;
using System.Threading.Tasks;
using Aerospike.Client;

namespace Dapper.Aerospike
{
    public static class SetClientQueryExtensions
    {
        public static Task<List<TEntity>> Query<TEntity>(this ISet<TEntity> set)
        {
            return set.Query(new QueryPolicy());
        }


        public static Task<List<TEntity>> Query<TEntity>(this ISet<TEntity> set,
                                                         QueryPolicy queryPolicy)
        {
            var entities = new List<TEntity>();

            using var records = set.Client.Query(queryPolicy,
                                                 new Statement
                                                 {
                                                     Namespace = set.Namespace,
                                                     SetName = set.Name
                                                 });
            while (records.Next())
            {
                entities.Add(set.GetEntity(records.Record));
            }

            return Task.FromResult(entities);
        }

        public static Task<List<TEntity>> Query<TEntity>(this ISet<TEntity> set,
                                                         QueryPolicy queryPolicy,
                                                         Statement statement)
        {
            var entities = new List<TEntity>();

            using var records = set.Client.Query(queryPolicy, statement);
            while (records.Next())
            {
                entities.Add(set.GetEntity(records.Record));
            }

            return Task.FromResult(entities);
        }
    }
}