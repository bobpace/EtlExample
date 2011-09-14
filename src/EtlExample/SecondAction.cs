using System.Collections.Generic;
using Rhino.Etl.Core;
using Rhino.Etl.Core.Operations;

namespace EtlExample
{
    public class SecondAction : AbstractOperation
    {
        public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
        {
            foreach (var value in rows)
            {
                Utilities.Log("secondAction: {0}", value["id"]);
                yield return value;
            }
        }
    }
}