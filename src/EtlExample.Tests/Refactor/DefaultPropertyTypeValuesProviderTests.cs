using System.Linq;
using EtlExample.Refactor;
using Xunit;

namespace EtlExample.Tests.Refactor
{
    public class DefaultPropertyTypeValuesProviderTests : Verifies<IPropertyTypeValuesProvider, DefaultPropertyTypeValuesProvider>
    {
        [Fact]
        public void should_return_all_enum_values_as_key_value_pairs()
        {
            var propertyTypes = SUT.GetPropertyTypes<TestEnum>();
            Assert.Equal(propertyTypes.ElementAt(0).Key, 0);
            Assert.Equal(propertyTypes.ElementAt(0).Value, "Value0");
            Assert.Equal(propertyTypes.ElementAt(1).Key, 1);
            Assert.Equal(propertyTypes.ElementAt(1).Value, "Value1");
            Assert.Equal(propertyTypes.ElementAt(2).Key, 2);
            Assert.Equal(propertyTypes.ElementAt(2).Value, "Value2");
        }

        private enum TestEnum
        {
            Value0,
            Value1,
            Value2,
        }
    }
}