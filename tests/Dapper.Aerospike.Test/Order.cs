using System;
using AtEase.Extensions.Numbers;

namespace Dapper.Aerospike.Test
{
    public class Order
    {

        public static Order CreateOrderWithDefaultValue()
        {
            return new Order()
            {
                Id = LongExtensions.NextRandom(),
                Number = "1",
                Time = DateTime.Now,
                PersonId = Guid.NewGuid()
            };

        }

        public Guid PersonId { get; set; }
        public long Id { get; set; }
        public DateTime Time { get; set; }
        public string Number { get; set; }
    }
}