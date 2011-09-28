using System.Linq;
using EtlExample.Refactor;
using NUnit.Framework;

namespace EtlExample.Tests.Refactor
{
    [TestFixture]
    public class DefaultPropertyTypeValuesProviderTests
    {
        DefaultPropertyTypeValuesProvider SUT;

        [SetUp]
        public void SetUp()
        {
            SUT = new DefaultPropertyTypeValuesProvider();
        }

        [Test]
        public void should_return_all_enum_values_as_key_value_pairs()
        {
            var propertyTypes = SUT.GetPropertyTypes<TestEnum>().ToList();
            Assert.AreEqual(propertyTypes[0].Key, 0);
            Assert.AreEqual(propertyTypes[0].Value, "Value0");
            Assert.AreEqual(propertyTypes[1].Key, 1);
            Assert.AreEqual(propertyTypes[1].Value, "Value1");
            Assert.AreEqual(propertyTypes[2].Key, 2);
            Assert.AreEqual(propertyTypes[2].Value, "Value2");
        }

        private enum TestEnum
        {
            Value0,
            Value1,
            Value2,
        }
    }
}