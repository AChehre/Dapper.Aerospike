using System;

namespace Dapper.Aerospike.Test
{
    public class Order
    {

        public static Order CreateOrderWithDefaultValue()
        {
            return new Order()
            {
                Id = 1,
                Number = "1",
                Time = DateTime.Now
            };

        }

        public long Id { get; set; }
        public DateTime Time { get; set; }
        public string Number { get; set; }
    }
}