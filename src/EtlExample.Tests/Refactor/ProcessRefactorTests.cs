using System.Collections.Generic;
using EtlExample.Refactor;
using NUnit.Framework;
using Row = Rhino.Etl.Core.Row;

namespace EtlExample.Tests.Refactor
{
    [TestFixture]
    public class ProcessRefactorTests
    {
        [Test]
        public void deferred_execution_on_execute()
        {
            var row = new Row
            {
                {"locationIdentifier", "1"},
                {"serviceArea", "redv2"},
                {"locationDescription", "redv3"},
                {"locationUrl", "redv4"},
                {"locationLogoName", "redv5"},
                {"locationPhotoNames", "redv6"},
                {"keywords", "redv7"},
            };
            var process = new ProcessRefactor();
            var enumerable = process.Execute(row);
            var enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
            }
        }
    }
}