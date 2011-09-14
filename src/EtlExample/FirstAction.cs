using System.Collections.Generic;
using System.Linq;
using Rhino.Etl.Core;
using Rhino.Etl.Core.Operations;

namespace EtlExample
{
    public class FirstAction : AbstractOperation
    {
        public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
        {
            foreach (var value in Enumerable.Range(0, 100000))
            {
                var row = new Row();
                Utilities.Log("firstAction: {0}", value);
                row["id"] = value;
                yield return row;
            }
        }
    }
}