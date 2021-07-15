using System.Threading;
using System.Threading.Tasks;
using Aerospike.Client;

namespace Dapper.Aerospike
{
    public static class SetPutExtensions
    {
        public static Task Put<TEntity>(this ISet<TEntity> set,
                                        TEntity entity)
        {
            return set.Put(entity, CancellationToken.None);
        }

        public static Task Put<TEntity>(this ISet<TEntity> set,
                                        WritePolicy writePolicy,
                                        TEntity entity)
        {
            return set.Put(writePolicy, entity, CancellationToken.None);
        }
    }
}