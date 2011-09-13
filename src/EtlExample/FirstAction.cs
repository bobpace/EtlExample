using System.Collections.Generic;
using Rhino.Etl.Core;
using Rhino.Etl.Core.Operations;

namespace EtlExample
{
    public class FirstAction : AbstractOperation
    {
        public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
        {
            Utilities.Log("first");
            yield return new Row();
            Utilities.Log("first");
            yield return new Row();
            Utilities.Log("first");
            yield return new Row();
            Utilities.Log("first");
            yield return new Row();
        }
    }
}