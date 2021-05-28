using System;
using System.Threading;
using System.Threading.Tasks;
using Aerospike.Client;
using Dapper.Aerospike.Test;
using FluentAssertions;
using Xunit;

namespace Dapper.Aerospike.Client.Test
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

    public class AsyncClientTests : IClassFixture<AerospikeFixture>
    {
        private readonly IAsyncClient _client;

        public AsyncClientTests(AerospikeFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task Add_should_add_entity_to_database()
        {
            var set = new Set<Order>(_client, OrderSetHelper.Namespace).SetNameAsEntity();
            set.KeyProperty(o => o.Id);
            set.Property(o => o.Number);

            var order = Order.CreateOrderWithDefaultValue();


            var writePolicy = new WritePolicy();
            await set.Add(writePolicy, order, CancellationToken.None);

            var result = set.Client.Get(new Policy(), CancellationToken.None, set.Key(order)).Result;

            result.Should().NotBeNull();
            result.bins.Count.Should().Be(2);
        }

        [Fact]
        public async Task Add_with_default_policy_should_add_entity_to_database()
        {
            var set = new Set<Order>(_client, OrderSetHelper.Namespace).SetNameAsEntity();
            set.KeyProperty(o => o.Id);
            set.Property(o => o.Number);

            var order = Order.CreateOrderWithDefaultValue();


            await set.Add(order, CancellationToken.None);

            var result = set.Client.Get(new Policy(), CancellationToken.None, set.Key(order)).Result;

            result.Should().NotBeNull();
            result.bins.Count.Should().Be(2);
        }
    }
}