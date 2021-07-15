using System.Threading;
using System.Threading.Tasks;
using Aerospike.Client;

namespace Dapper.Aerospike
{
    public static class SetClientPutExtensions
    {
        public static Task Put<TEntity>(this ISet<TEntity> set,
                                        TEntity entity,
                                        CancellationToken token)
        {
            return set.Client.Put(new WritePolicy(), token, set.Key(entity), set.GetBins(entity));
        }

        public static Task Put<TEntity>(this ISet<TEntity> set,
                                        WritePolicy writePolicy,
                                        TEntity entity,
                                        CancellationToken token)
        {
            return set.Client.Put(writePolicy, token, set.Key(entity), set.GetBins(entity));
        }
       
    }
}