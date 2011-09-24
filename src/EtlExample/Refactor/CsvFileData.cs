using System;
using System.Collections.Generic;
using System.Linq;

namespace EtlExample.Refactor
{
    public class CsvFileData
    {
        IDictionary<string, IDictionary<string, string>> _data;

        public IEnumerable<T> SelectRowsAs<T>(Func<IDictionary<string,string>, T> selectAction)
        {
            return _data.Keys
                .Select(x => _data[x])
                .Select(selectAction);
        }
    }
}