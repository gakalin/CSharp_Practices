using System;
using System.Linq;
using System.Threading.Tasks;

namespace plinq_asparallel_parallelquery
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            const int count = 50;

            var items = Enumerable.Range(1, count).ToArray();
            var results = new int[count];

            items.AsParallel().ForAll(x =>
            {
                int newValue = x * x * x;
                Console.Write($"{newValue} ({Task.CurrentId})\t");
                results[x - 1] = newValue;
            });

            Console.WriteLine();
            Console.WriteLine();

            /*foreach (var i in results)
            {
                Console.WriteLine($"{i}");
            }

            Console.WriteLine();*/

            var cubes = items.AsParallel().AsOrdered().Select(x => x*x*x);

            // var arr = cubes.ToArray();
            
            // only calculates when use (like foreach or toArray)
            foreach (var i in cubes)
                Console.Write($"{i}\t");
            Console.WriteLine();

        }
    }
}