using System.Threading;
using System.Threading.Tasks;
using Aerospike.Client;
using Dapper.Aerospike.Test;
using FluentAssertions;
using Xunit;

namespace Dapper.Aerospike.Client.Test
{
    public class GetWithValueBuilderTests : IClassFixture<AerospikeFixture>
    {
        private readonly IAsyncClient _client;

        public GetWithValueBuilderTests(AerospikeFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task Get_should_get_entity_from_database()
        {
            var order = Order.CreateOrderWithDefaultValue();


            var set = new Set<Order>(_client, OrderSetHelper.Namespace).SetNameAsEntity();
            set.KeyProperty(o => o.Id);
            set.Property(o => o.Number);
            set.Property(o => o.PersonId);
            set.Property(o => o.Time);

            set.SetValueBuilder((record, properties) =>
            {
                var id = record.GetLong(properties[nameof(Order.Id)].PropertyName);
                var number = record.GetString(properties[nameof(Order.Number)].PropertyName);
                var personId = record.GetGuid(properties[nameof(Order.PersonId)].PropertyName);
                var time = record.GetDateTime(properties[nameof(Order.Time)].PropertyName);
                return new Order
                {
                    Id = id,
                    Number = number,
                    PersonId = personId,
                    Time = time
                };
            });

            await set.Add(order, CancellationToken.None);


            var result = set.Get(new Policy(), order, CancellationToken.None).Result;

            result.Should().BeEquivalentTo(order);
        }


        [Fact]
        public async Task Get_with_default_policy_should_get_entity_from_database()
        {
            var order = Order.CreateOrderWithDefaultValue();


            var set = new Set<Order>(_client, OrderSetHelper.Namespace).SetNameAsEntity();
            set.KeyProperty(o => o.Id);
            set.Property(o => o.Number);
            set.Property(o => o.PersonId);
            set.Property(o => o.Time);

            set.SetValueBuilder((record, properties) =>
            {
                var id = record.GetLong(properties[nameof(Order.Id)].PropertyName);
                var number = record.GetString(properties[nameof(Order.Number)].PropertyName);
                var personId = record.GetGuid(properties[nameof(Order.PersonId)].PropertyName);
                var time = record.GetDateTime(properties[nameof(Order.Time)].PropertyName);
                return new Order
                {
                    Id = id,
                    Number = number,
                    PersonId = personId,
                    Time = time
                };
            });


            await set.Add(order, CancellationToken.None);

            var result = set.Get(order, CancellationToken.None).Result;

            result.Should().BeEquivalentTo(order);
        }
    }
}