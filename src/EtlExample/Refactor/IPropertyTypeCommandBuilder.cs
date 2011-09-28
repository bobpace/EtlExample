using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EtlExample.Refactor
{
    public interface IPropertyTypeCommandBuilder
    {
        IEnumerable<SqlCommand> GetPropertyTypeCommandsFor<T>(CreatePropertyTypeCommand<T> commandCreator) where T : struct, IConvertible;
    }
}