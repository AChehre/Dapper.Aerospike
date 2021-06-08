using System;
using Aerospike.Client;
using Dapper.Aerospike.Test;

namespace Dapper.Aerospike.Client.Test.Set
{
    public class AerospikeFixture : IDisposable
    {
        public AerospikeFixture()
        {
            Client = new AsyncClient("127.0.0.2", 3000);
            Client.Truncate(new InfoPolicy(), OrderSetHelper.Namespace, nameof(Order), null);
        }

        public IAsyncClient Client { get; }

        public void Dispose()
        {
            // clean up 
        }
    }

}