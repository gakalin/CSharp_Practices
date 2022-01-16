using System;
using System.Threading;
using System.Threading.Tasks;

namespace task_barrier
{
    internal class Program
    {
        private static Barrier barrier = new Barrier(2, b =>
        {
            Console.WriteLine($"Phase {b.CurrentPhaseNumber} is finished");
        });

        public static void Water()
        {
            Console.WriteLine("putting the kettle on (takes a bit longer)");
            Thread.Sleep(2000);
            barrier.SignalAndWait();
            Console.WriteLine("pouring water into cup.");
            barrier.SignalAndWait();
            Console.WriteLine("putting the kettle away");
        }

        public static void Cup()
        {
            Console.WriteLine("finding the nicest cup of tea (fast)");
            barrier.SignalAndWait();
            Console.WriteLine("adding tea");
            barrier.SignalAndWait();
            Console.WriteLine("adding sugar");
        }
        
        public static void Main(string[] args)
        {
            var water = Task.Factory.StartNew((Water));
            var cup = Task.Factory.StartNew(Cup);

            var tea = Task.Factory.ContinueWhenAll(new [] {water, cup}, tasks =>
            {
                Console.WriteLine("enjoy your cup of tea");
            });

            tea.Wait();
        }
    }
}