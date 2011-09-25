using System;
using System.Collections.Generic;

namespace EtlExample.Refactor
{
    public class StubPropertyTypeValuesProvider : IPropertyTypeValuesProvider
    {
        public IEnumerable<KeyValuePair<int, string>> GetPropertyTypes<T>() where T : struct, IConvertible
        {
            yield return new KeyValuePair<int, string>(0, "hello0");
            yield return new KeyValuePair<int, string>(1, "hello1");
            yield return new KeyValuePair<int, string>(2, "hello2");
            yield return new KeyValuePair<int, string>(3, "hello3");
        }
    }
}