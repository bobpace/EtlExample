using Xunit;

namespace EtlExample.Tests
{
    //watch the order the console statements are written and what thread id they are written from
    public class EtlTests
    {
        [Fact]
        public void Multi_threaded_test()
        {
            //default value of PipelineExecuter property on EtlProcess class is ThreadPoolPipelineExecuter
            //making any process you don't specifically set the single threaded pipe line executor on a
            //multi threaded process by default
            var process = new MainProcess();
            process.Execute();
        }

        [Fact]
        public void Single_threaded_test()
        {
            var process = new SingleThreadedMainProcess();
            process.Execute();
        }
    }
}