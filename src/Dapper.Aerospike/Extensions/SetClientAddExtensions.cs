using System.Threading;
using System.Threading.Tasks;
using Aerospike.Client;

namespace Dapper.Aerospike
{
    public static class SetClientAddExtensions
    {
        public static Task Add<TEntity>(this ISet<TEntity> set,
                                        TEntity entity,
                                        CancellationToken token)
        {
            var bins = set.GetBins(entity);
            return set.Client.Add(new WritePolicy(), token, set.Key(entity), bins);
        }
        public static Task Add<TEntity>(this ISet<TEntity> set,
                                        WritePolicy writePolicy,
                                        TEntity entity,
                                        CancellationToken token)
        {
            return set.Client.Add(writePolicy, token, set.Key(entity), set.GetBins(entity));
        }
    }
}