using System.Threading;
using System.Threading.Tasks;
using Aerospike.Client;

namespace Dapper.Aerospike
{
    public static class SetAddExtensions
    {
        public static Task Add<TEntity>(this ISet<TEntity> set,
                                        TEntity entity)
        {
            return set.Add(entity, CancellationToken.None);
        }

        public static Task Add<TEntity>(this ISet<TEntity> set,
                                        WritePolicy writePolicy,
                                        TEntity entity)
        {
            return set.Add(writePolicy, entity, CancellationToken.None);
        }
    }
}