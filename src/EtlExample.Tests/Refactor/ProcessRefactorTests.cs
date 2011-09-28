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
            var row = new Row();
            row["locationIdentifier"] = "1";
            row["serviceArea"] = null;
            row["locationDescription"] = "null";
            row["locationUrl"] = "NULL";
            row["locationLogoName"] = "redv5";
            row["locationPhotoNames"] = "redv6";
            row["keywords"] = "redv7";

            var process = new ProcessRefactor();
            var enumerable = process.Execute(row);
            var enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var sqlCommand = enumerator.Current;
                Assert.IsTrue(!string.IsNullOrEmpty(sqlCommand.CommandText));
            }
        }
    }
}