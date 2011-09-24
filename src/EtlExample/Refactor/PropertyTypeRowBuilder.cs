using System;
using System.Collections.Generic;
using System.Linq;
using Rhino.Etl.Core;

namespace EtlExample.Refactor
{
    public class PropertyTypeRowBuilder : IPropertyTypeRowBuilder
    {
        readonly IPropertyTypeValuesProvider _propertyTypeValuesProvider;
        readonly int _id;
        readonly IDictionary<string, string> _data;

        public PropertyTypeRowBuilder()
        {
        }

        public PropertyTypeRowBuilder(int id, IDictionary<string, string> data)
            : this(new DefaultPropertyTypeValuesProvider(), id, data)
        {
        }

        public PropertyTypeRowBuilder(IPropertyTypeValuesProvider propertyTypeValuesProvider,
                                      int id,
                                      IDictionary<string, string> data)
        {
            _propertyTypeValuesProvider = propertyTypeValuesProvider;
            _id = id;
            _data = data;
        }

        public IEnumerable<Row> GetPropertyTypeRowsFor<T>(CreatePropertyTypeRow<T> rowCreator) where T : struct, IConvertible
        {
            return _propertyTypeValuesProvider
                .GetPropertyTypes<T>()
                .Select(kvp => kvp.ChangeValue(x => x.ChangeFirstLetterToLower()))
                .Select(kvp => kvp.ChangeValue(x => _data[x]))
                .TakeWhile(kvp => !string.IsNullOrEmpty(kvp.Value) && kvp.Value.ToLower() != "null")
                .Select(kvp => rowCreator(_id, kvp.Key, kvp.Value));
        }

        public IEnumerable<Row> GetPropertyTypeRowsFor<T>() where T : struct, IConvertible
        {
            return GetPropertyTypeRowsFor<T>((x, y, z) => DefaultRow(x, y, z, typeof (T)));
        }

        public static Row DefaultRow(int id, int propertyTypeId, string propertyValue, Type propertyTypeEnum)
        {
            var typeName = propertyTypeEnum.Name;
            var idColumnName = string.Format("{0}ID", typeName.Replace("PropertyType", ""));
            var propertyTypeIdColumnName = string.Format("{0}ID", typeName);

            var row = new Row();
            row[idColumnName] = id;
            row[propertyTypeIdColumnName] = propertyTypeId;
            row["PropertyValue"] = propertyValue;
            return row;
        }
    }
}