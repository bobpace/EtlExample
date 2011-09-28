using System.Collections.Generic;
using EtlExample.Refactor;
using Xunit;

namespace EtlExample.Tests.Refactor
{
    public class ProcessRefactorTests : Verifies<ProcessRefactor>
    {
        [Fact]
        public void deferred_execution_on_execute()
        {
            var data = new Dictionary<string, IDictionary<string, string>>
            {
                {
                    "red",
                    new Dictionary<string, string>
                    {
                        {"locationIdentifier", "1"},
                        {"serviceArea", "redv2"},
                        {"locationDescription", "redv3"},
                        {"locationUrl", "redv4"},
                        {"locationLogoName", "redv5"},
                        {"locationPhotoNames", "redv6"},
                        {"keywords", "redv7"},
                    }
                    },
                {
                    "blue",
                    new Dictionary<string, string>
                    {
                        {"locationIdentifier", "2"},
                        {"serviceArea", "bluev2"},
                        {"locationDescription", "bluev3"},
                        {"locationUrl", "bluev4"},
                        {"locationLogoName", "bluev5"},
                        {"locationPhotoNames", "bluev6"},
                        {"keywords", "bluev7"},
                    }
                    },
                {
                    "green",
                    new Dictionary<string, string>
                    {
                        {"locationIdentifier", "2"},
                        {"serviceArea", "greenv2"},
                        {"locationDescription", "greenv3"},
                        {"locationUrl", "greenv4"},
                        {"locationLogoName", "greenv5"},
                        {"locationPhotoNames", "greenv6"},
                        {"keywords", "greenv7"},
                    }
                    },
            };
            var process = new ProcessRefactor
            {
                CsvFileData = new CsvFileData(data)
            };
            var enumerable = process.Execute(null);
            var enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
            }
        }
    }
}