using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerospike.Client;
using FluentAssertions;
using Xunit;

namespace Dapper.Aerospike.Test
{
    public class KeyTests
    {
        [Fact]
        public void _should_return_empty_list_when_not_any_property_added()
        {
            var order = Order.CreateOrderWithDefaultValue();
            Set<Order> set = new Set<Order>();

            Bin[] bins = set.GetBins(order);


            bins.Should().BeNullOrEmpty();
        }
    }
}
