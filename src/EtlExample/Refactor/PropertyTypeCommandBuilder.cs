﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using Row = Rhino.Etl.Core.Row;

namespace EtlExample.Refactor
{
    public class PropertyTypeCommandBuilder : IPropertyTypeCommandBuilder
    {
        readonly IPropertyTypeValuesProvider _propertyTypeValuesProvider;
        readonly int _id;
        readonly Row _data;

        public PropertyTypeCommandBuilder(IPropertyTypeValuesProvider propertyTypeValuesProvider,
                                      int id,
                                      Row data)
        {
            _propertyTypeValuesProvider = propertyTypeValuesProvider;
            _id = id;
            _data = data;
        }

        public IEnumerable<SqlCommand> GetPropertyTypeCommandsFor<T>(CreatePropertyTypeCommand<T> commandCreator) where T : struct, IConvertible
        {
            Debug.WriteLine("GetPropertyTypeCommandsFor");
            return _propertyTypeValuesProvider
                .GetPropertyTypes<T>()
                .Select(kvp => kvp.ChangeValue(x => x.ChangeFirstLetterToLower()))
                .Select(kvp => kvp.ChangeValue(x => (string)_data[x]))
                .Where(kvp => !string.IsNullOrEmpty(kvp.Value) && kvp.Value.ToLower() != "null")
                .Select(kvp => commandCreator(_id, kvp.Key, kvp.Value));
        }
    }
}