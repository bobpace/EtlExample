using System;
using Rhino.Etl.Core;

namespace EtlExample
{
    public class MainProcess : EtlProcess
    {
        protected override void Initialize()
        {
            //default value of PipelineExecuter is ThreadPoolPipelineExecuter
            Register(new FirstAction());
            Register(new SecondAction());
        }
    }
}