using System;
using System.Linq;

namespace plinq_merge_options
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Enumerable.Range(1, 20).ToArray();

            var results = numbers
                .AsParallel()
                .WithMergeOptions(ParallelMergeOptions.FullyBuffered)
                .Select(x =>
                {
                    var result = Math.Log10(x);
                    Console.Write($"p {result}\t");
                    return result;
                });

            foreach (var result in results)
            {
                Console.Write($"c {result}\t");
            }
        }
    }
}