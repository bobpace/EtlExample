using System;
using System.Collections.Generic;
using Rhino.Etl.Core;

namespace EtlExample.Refactor
{
    public interface IPropertyTypeRowBuilder
    {
        IEnumerable<Row> GetPropertyTypeRowsFor<T>(CreatePropertyTypeRow<T> rowCreator) where T : struct, IConvertible;
        IEnumerable<Row> GetPropertyTypeRowsFor<T>() where T : struct, IConvertible;
    }
}