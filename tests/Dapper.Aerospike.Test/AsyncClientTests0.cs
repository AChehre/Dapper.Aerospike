using System.Threading;
using System.Threading.Tasks;
using Aerospike.Client;
using Xunit;

namespace Dapper.Aerospike.Test
{
    public class AsyncClientTests
    {
        [Fact]
        public void Test()
        {
            IAsyncClient client = new AsyncClient("100", 1010);


            // define set
            var set = new Set<Order>(client, "namespace");
            set.KeyProperty(o => o.Id);
            set.Property(o => o.Number);
            set.Property(o => o.Time);


            // add order
            //set.Add(new Order());

            // update order
            //set.Update(new Order());
        }
    }

    public static class SetExtensions
    {
        public static Task Add<TEntity>(this Set<TEntity> set,WritePolicy writePolicy,  TEntity entity, CancellationToken token)
        {
            return set.Client.Add(writePolicy,CancellationToken.None, set.Key(entity),set.GetBins(entity));
        }
    }

}