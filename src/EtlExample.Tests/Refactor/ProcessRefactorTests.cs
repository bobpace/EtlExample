using System.Collections.Generic;
using EtlExample.Refactor;
using Rhino.Etl.Core;
using Xunit;

namespace EtlExample.Tests.Refactor
{
    public class ProcessRefactorTests
    {
        ProcessRefactor _refactor;
        IEnumerable<Row> _result;

        public ProcessRefactorTests()
        {
            _refactor = new ProcessRefactor();
        }

        [Fact]
        public void When_returning_rows()
        {
            _result = _refactor.Execute(null);
        }
    }
}