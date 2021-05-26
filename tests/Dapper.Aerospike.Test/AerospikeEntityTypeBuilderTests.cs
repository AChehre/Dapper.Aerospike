using FluentAssertions;
using Xunit;

namespace Dapper.Aerospike.Test
{
    public class AerospikeEntityTypeBuilderTests

    {
        [Fact]
        public void GetBins_should_return_array_of_bin()
        {
            var set =OrderSetHelper.CreateOrderSet();
            set.Property(p => p.Id);
            set.Property(p => p.Number);


            var expectedBins = new[]
            {
                nameof(Order.Id),
                nameof(Order.Number)
            };


            var bins = set.GetBinNames();


            bins.Should().BeEquivalentTo(expectedBins);
        }


        [Fact]
        public void GetBinNames_with_property_as_func_parameter_should_return_array_of_properties_bin()
        {
            var set =OrderSetHelper.CreateOrderSet();
            set.Property(p => p.Id);
            set.Property(p => p.Number);


            var expectedBins = new[]
            {
                nameof(Order.Id),
                nameof(Order.Number)
            };


            var bins = set.GetBinNames(o => o.Id, o => o.Number);


            bins.Should().BeEquivalentTo(expectedBins);
        }

        [Fact]
        public void GetBinNames_with_property_should_return_array_of_properties_bin()
        {
            var set =OrderSetHelper.CreateOrderSet();
            set.Property(p => p.Id);
            set.Property(p => p.Number);


            var expectedBins = new[]
            {
                nameof(Order.Id),
                nameof(Order.Number)
            };


            var bins = set.GetBinNames(nameof(Order.Id), nameof(Order.Number));


            bins.Should().BeEquivalentTo(expectedBins);
        }


        [Fact]
        public void GetBins_with_property_should_return_array_of_properties_bin()
        {
            var set =OrderSetHelper.CreateOrderSet();
            set.Property(p => p.Id);
            set.Property(p => p.Number);


            var expectedBins = new[]
            {
                nameof(Order.Id),
                nameof(Order.Number)
            };


            var bins = set.GetBinNames(nameof(Order.Id),
                                       nameof(Order.Number));


            bins.Should().BeEquivalentTo(expectedBins);
        }


        [Fact]
        public void GetProperty_when_bin_name_not_provided_should_return_property_name()
        {
            var set =OrderSetHelper.CreateOrderSet();
            set.Property(p => p.Id);


            var expectedBin = nameof(Order.Id);

            var prop = set.GetProperty(p => p.Id);
            prop.PropertyName.Should().Be(nameof(Order.Id));
            prop.BinName.Should().Be(expectedBin);
        }


        [Fact]
        public void GetPropertyMapTest()
        {
            var bin = "id";
            var set =OrderSetHelper.CreateOrderSet();
            set.Property(p => p.Id, bin);


            var prop = set.GetProperty(p => p.Id);
            prop.PropertyName.Should().Be(nameof(Order.Id));
            prop.BinName.Should().Be(bin);
                       prop.Type.Should().Be(typeof(long));
        }
    }
}