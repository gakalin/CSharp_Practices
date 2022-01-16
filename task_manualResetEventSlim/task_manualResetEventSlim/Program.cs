using System;
using System.Threading;
using System.Threading.Tasks;

namespace task_manualResetEventSlim
{
    internal class Program
    {
        public static void ManualResetEventSlim_Example()
        {
            var evt = new ManualResetEventSlim();

            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("boiling water");
                evt.Set();
            });

            var makeTea = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("waiting for water...");
                evt.Wait();
                Console.WriteLine("here is your tea");
            });

            makeTea.Wait();
        }
        
        public static void AutoResetEvent_Example()
        {
            var evt = new AutoResetEvent(false);

            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("boiling water");
                evt.Set(); // true
            });

            var makeTea = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("waiting for water...");
                evt.WaitOne(); // false
                Console.WriteLine("here is your tea");
                var ok = evt.WaitOne(1000); // false

                if (ok)
                {
                    Console.WriteLine("enjoy your tea");
                }
                else
                {
                    Console.WriteLine("no tea for you");
                }
            });

            makeTea.Wait();
        }
        public static void Main(string[] args)
        {
            //ManualResetEventSlim_Example();
            AutoResetEvent_Example();
        }
    }
}