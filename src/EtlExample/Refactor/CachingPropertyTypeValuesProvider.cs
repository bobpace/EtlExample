using System;
using System.Collections.Generic;

namespace EtlExample.Refactor
{
    public class CachingPropertyTypeValuesProvider : IPropertyTypeValuesProvider
    {
        readonly IPropertyTypeValuesProvider _valuesProvider;
        readonly IDictionary<Type, IEnumerable<KeyValuePair<int, string>>>  _valuesCache;

        public CachingPropertyTypeValuesProvider(IPropertyTypeValuesProvider valuesProvider)
        {
            _valuesProvider = valuesProvider;
            _valuesCache = new Dictionary<Type, IEnumerable<KeyValuePair<int, string>>>();
        }

        public IEnumerable<KeyValuePair<int, string>> GetPropertyTypes<T>() where T : struct, IConvertible
        {
            var type = typeof(T);
            if (!_valuesCache.ContainsKey(type))
            {
                _valuesCache[type] = _valuesProvider.GetPropertyTypes<T>();
            }
            return _valuesCache[type];
        }
    }
}