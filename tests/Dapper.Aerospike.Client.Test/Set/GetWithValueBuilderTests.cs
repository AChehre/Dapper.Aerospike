using System.Threading;
using System.Threading.Tasks;
using Aerospike.Client;
using Dapper.Aerospike.Test;
using FluentAssertions;
using Xunit;

namespace Dapper.Aerospike.Client.Test.Set
{
    public class GetTests : IClassFixture<AerospikeFixture>
    {
        private readonly IAsyncClient _client;

        public GetTests(AerospikeFixture fixture)
        {
            _client = fixture.Client;
        }
        
        [Fact]
        public async Task Get_bulk_should_get_entities_from_database()
        {
            Set<Order> set = OrderSetHelper.CreateOrderSetWithProperties();
            set.SetClient(_client);


            Order order = Order.CreateOrderWithDefaultValue();
            await set.Add(order);

            Order order2 = Order.CreateOrderWithSecondDefaultValue();
            await set.Add(order2);

            long[] ids = new[] { order.Id, order2.Id };

            Order[] result = set.Get(ids).Result;

            result.Should()
                  .NotBeEmpty()
                  .And.BeEquivalentTo(new[] { order, order2 });
        }

        [Fact]
        public async Task Get_bulk_with_object_id_should_get_entities_from_database()
        {
            Set<Order> set = OrderSetHelper.CreateOrderSetWithProperties();
            set.SetClient(_client);


            Order order = Order.CreateOrderWithDefaultValue();
           await set.Add(order);

           Order order2 = Order.CreateOrderWithSecondDefaultValue();
           await set.Add(order2);

           object[] ids = new [] {(object)order.Id, (object)order2.Id};

            Order[] result = set.Get(ids).Result;

            result.Should()
                  .NotBeEmpty()
                  .And.BeEquivalentTo(new[]{order,order2});
        }

        [Fact]
        public async Task Get_should_get_entity_from_database()
        {
            Order order = Order.CreateOrderWithDefaultValue();

            Set<Order> set = OrderSetHelper.CreateOrderSetWithProperties();
            set.SetClient(_client);

            await set.Add(order, CancellationToken.None);


            Order result = set.Get(new Policy(), order, CancellationToken.None).Result;

            result.Should().BeEquivalentTo(order);
        }

        [Fact]
        public async Task Get_with_object_id_should_get_entity_from_database()
        {
            Order order = Order.CreateOrderWithDefaultValue();

            Set<Order> set = OrderSetHelper.CreateOrderSetWithProperties();
            set.SetClient(_client);

            await set.Add(order, CancellationToken.None);


            Order result = set.Get((object)order.Id).Result;

            result.Should().BeEquivalentTo(order);
        }

        [Fact]
        public async Task Get_with_default_policy_should_get_entity_from_database()
        {
            Order order = Order.CreateOrderWithDefaultValue();

            Set<Order> set = OrderSetHelper.CreateOrderSetWithProperties();
            set.SetClient(_client);


            await set.Add(order, CancellationToken.None);

            Order result = set.Get(order.Id, CancellationToken.None).Result;

            result.Should().BeEquivalentTo(order);
        }
    }
}