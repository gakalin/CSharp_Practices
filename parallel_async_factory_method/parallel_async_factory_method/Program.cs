using System.Threading;
using System.Threading.Tasks;

namespace parallel_async_factory_method
{
    public class Foo
    {
        private Foo()
        {
            
        }

        private async Task<Foo> InitAsync()
        {
            await Task.Delay(1000);
            return this;
        }

        public static Task<Foo> CreateAsync()
        {
            var result = new Foo();
            return result.InitAsync();
        }
    }
    
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            // var foo = new Foo();
            // await foo.InitAsync();

            Foo x = await Foo.CreateAsync();
            
        }
    }
}