using System;
using Rhino.Etl.Core;

namespace EtlExample.Refactor
{
    public delegate Row CreatePropertyTypeRow<T>(int id, int propertyTypeId, string propertyValue)
        where T : struct, IConvertible;
}