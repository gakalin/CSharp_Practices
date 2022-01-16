using System;
using System.Threading;
using System.Threading.Tasks;

namespace parallel_breakingCancellationExceptions
{
    internal class Program
    {
        private static ParallelLoopResult result;
        public static void Demo()
        {
            var cts = new CancellationTokenSource();

            ParallelOptions po = new ParallelOptions();
            po.CancellationToken = cts.Token;
            
            result = Parallel.For(0, 20, po, (int x, ParallelLoopState state) =>
            {
                Console.WriteLine($"{x}[{Task.CurrentId}]\t");
                if (x == 10)
                {
                    // throw new Exception();
                    //state.Stop();
                    //state.Break();
                    cts.Cancel();
                }
            });
            Console.WriteLine();
            Console.WriteLine($"was loop completed? {result.IsCompleted}");
            if (result.LowestBreakIteration.HasValue)
            {
                Console.WriteLine($"lowest break iteration is {result.LowestBreakIteration}");
            }
        }
        public static void Main(string[] args)
        {
            try
            {
                Demo();
            }
            catch (AggregateException ae)
            {
                ae.Handle(e =>
                {
                    Console.WriteLine(e.Message);
                    return true;
                });
            }
            catch (OperationCanceledException oce)
            {
                Console.WriteLine(oce.Message);
            }
        }
    }
}