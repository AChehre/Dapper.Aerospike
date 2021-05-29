using Aerospike.Client;
using Dapper.Aerospike.Test;
using FluentAssertions;
using Xunit;

namespace Dapper.Aerospike.Client.Test
{
    public class SetClientTests : IClassFixture<AerospikeFixture>
    {
        private readonly IAsyncClient _client;

        public SetClientTests(AerospikeFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public void SetClient_should_set_the_client()
        {
            Set<Order> set = OrderSetHelper.CreateOrderSet();
            set.SetClient(_client);

            set.Client.Should().NotBeNull();
        }
    }
}