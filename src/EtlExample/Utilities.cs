using System;
using System.Threading;

namespace EtlExample
{
    public static class Utilities
    {
        public static void Log(string name)
        {
            var id = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("calling {0} from {1}", name, id);
        }

        public static void Log(string formatString, params object[] parameters)
        {
            Log(string.Format(formatString, parameters));
        }
    }
}