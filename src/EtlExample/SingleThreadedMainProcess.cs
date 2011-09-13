using Rhino.Etl.Core;
using Rhino.Etl.Core.Pipelines;

namespace EtlExample
{
    public class SingleThreadedMainProcess : EtlProcess
    {
        protected override void Initialize()
        {
            PipelineExecuter = new SingleThreadedPipelineExecuter();

            Register(new FirstAction());
            Register(new SecondAction());
        }
    }
}