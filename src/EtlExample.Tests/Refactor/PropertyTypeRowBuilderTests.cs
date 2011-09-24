// ReSharper disable InconsistentNaming
using System;
using System.Collections.Generic;
using System.Linq;
using EtlExample.Refactor;
using Rhino.Etl.Core;
using Xunit;

namespace EtlExample.Tests.Refactor
{
    public class PropertyTypeRowBuilderTests : Verifies<IPropertyTypeRowBuilder, PropertyTypeRowBuilder>
    {
        readonly int _id;
        readonly IDictionary<string, string> _data;

        public PropertyTypeRowBuilderTests()
        {
            _id = 100;
            _data = new Dictionary<string, string>
            {
                {"logoName", "value1"},
                {"photoName", "value2"},
                {"sampleName", "value3"},
            };

            Services.Container.Configure(
                x => x.For<PropertyTypeRowBuilder>()
                    .Use(() => new PropertyTypeRowBuilder(_id, _data)));
        }

        [Fact]
        public void get_property_type_rows_for_enum_produces_one_row_per_enum_value()
        {
            var enumerable = SUT.GetPropertyTypeRowsFor<SampleAddressPropertyType>();

            var enumLength = Enum.GetValues(typeof(SampleAddressPropertyType)).Length;
            Assert.Equal(enumerable.Count(), enumLength);
        }

        [Fact]
        public void and_fetches_value_from_data_dictionary_by_enum_name_with_first_letter_to_lowered()
        {
            var enumerable = SUT.GetPropertyTypeRowsFor<SampleAddressPropertyType>(
                //CreatePropertyTypeRow delegate provides testing hook as well as extensibility point
                (id, propertyTypeId, value) =>
                {
                    var originalEnumValue = (SampleAddressPropertyType) propertyTypeId;
                    var keyToFetchWith = originalEnumValue.ToString().ChangeFirstLetterToLower();
                    Assert.Equal(_data[keyToFetchWith], value);
                    return new Row();
                });
            //force enumeration of enumerable to assert test logic
            enumerable.Count();
        }

        [Fact]
        public void default_row_follows_convention_for_property_type_enums()
        {
            const int id = 1000;
            const int propertyTypeId = 1;
            const string value = "test";

            Row row = PropertyTypeRowBuilder.DefaultRow(id, propertyTypeId, value, typeof(SampleAddressPropertyType));
            Assert.Equal(row["SampleAddressID"], id);
            Assert.Equal(row["SampleAddressPropertyTypeID"], propertyTypeId);
            Assert.Equal(row["PropertyValue"], value);
        }

        private enum SampleAddressPropertyType
        {
            LogoName,
            PhotoName,
            SampleName
        }
    }
}
// ReSharper restore InconsistentNaming