using System;
using System.Collections.Generic;

namespace EtlExample.Refactor
{
    public interface IPropertyTypeValuesProvider
    {
        IEnumerable<KeyValuePair<int, string>> GetPropertyTypes<T>() where T : struct, IConvertible;
    }
}