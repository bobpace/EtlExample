﻿using System;
using System.Collections.Generic;
using System.Linq;
using EtlExample.Refactor;
using NUnit.Framework;
using Rhino.Etl.Core;

namespace EtlExample.Tests.Refactor
{
    [TestFixture]
    public class PropertyTypeRowBuilderTests
    {
        int _id;
        IDictionary<string, string> _data;
        PropertyTypeRowBuilder SUT;

        [SetUp]
        public void SetUp()
        {
            _id = 100;
            _data = new Dictionary<string, string>
            {
                {"logoName", "value1"},
                {"photoName", "value2"},
                {"sampleName", "value3"},
            };

            SUT = new PropertyTypeRowBuilder(new DefaultPropertyTypeValuesProvider(), _id, _data);
        }

        [Test]
        public void get_property_type_rows_for_enum_produces_one_row_per_enum_value()
        {
            var enumerable = SUT.GetPropertyTypeRowsFor<SampleAddressPropertyType>();

            var enumLength = Enum.GetValues(typeof(SampleAddressPropertyType)).Length;
            Assert.AreEqual(enumerable.Count(), enumLength);
        }

        [Test]
        public void and_fetches_value_from_data_dictionary_by_enum_name_with_first_letter_to_lowered()
        {
            var enumerable = SUT.GetPropertyTypeRowsFor<SampleAddressPropertyType>(
                //CreatePropertyTypeRow delegate provides testing hook as well as extensibility point
                (id, propertyTypeId, value) =>
                {
                    var originalEnumValue = (SampleAddressPropertyType) propertyTypeId;
                    var keyToFetchWith = originalEnumValue.ToString().ChangeFirstLetterToLower();
                    Assert.AreEqual(_data[keyToFetchWith], value);
                    return new Row();
                });
            //force enumeration of enumerable to assert test logic
            var enumerator = enumerable.GetEnumerator();
            while(enumerator.MoveNext())
            {
            }
        }

        [Test]
        public void default_row_follows_convention_for_property_type_enums()
        {
            const int id = 1000;
            const int propertyTypeId = 1;
            const string value = "test";

            Row row = PropertyTypeRowBuilder.DefaultRow(id, propertyTypeId, value, typeof(SampleAddressPropertyType));
            Assert.AreEqual(row["SampleAddressID"], id);
            Assert.AreEqual(row["SampleAddressPropertyTypeID"], propertyTypeId);
            Assert.AreEqual(row["PropertyValue"], value);
        }

        private enum SampleAddressPropertyType
        {
            LogoName,
            PhotoName,
            SampleName
        }
    }
}