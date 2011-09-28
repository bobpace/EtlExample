using System;
using System.Data.SqlClient;

namespace EtlExample.Refactor
{
    public delegate SqlCommand CreatePropertyTypeCommand<T>(int id, int propertyTypeId, string propertyValue)
        where T : struct, IConvertible;
}