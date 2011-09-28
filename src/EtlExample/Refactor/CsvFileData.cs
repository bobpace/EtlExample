using System;
using System.Collections.Generic;
using System.Linq;

namespace EtlExample.Refactor
{
    public class CsvFileData
    {
        readonly IDictionary<string, IDictionary<string, string>> _data;

        public CsvFileData()
            : this(new Dictionary<string, IDictionary<string, string>>())
        {
        }

        public CsvFileData(IDictionary<string, IDictionary<string,string>> data)
        {
            _data = data;
        }

        public IEnumerable<T> SelectRowsAs<T>(Func<IDictionary<string,string>, T> selectAction)
        {
            return _data.Keys
                .Select(x => _data[x])
                .Select(selectAction);
        }
    }
}