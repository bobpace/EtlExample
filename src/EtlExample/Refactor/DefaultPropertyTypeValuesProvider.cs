using System;
using System.Collections.Generic;
using System.Linq;

namespace EtlExample.Refactor
{
    public class DefaultPropertyTypeValuesProvider : IPropertyTypeValuesProvider
    {
        public IEnumerable<KeyValuePair<int, string>> GetPropertyTypes<T>() where T : struct, IConvertible
        {
            var enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("T must be an enum");
            }

            return Enum.GetValues(enumType)
                .Cast<int>()
                .Zip(Enum.GetNames(enumType), (key, value) => new KeyValuePair<int, string>(key, value));
        }
    }
}