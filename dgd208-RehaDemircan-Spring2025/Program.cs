using dgd208_RehaDemircan_Spring2025;
using System;
using System.Threading.Tasks;

namespace DG208_Spring2025_RehaDemircan
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Game game = new Game();
            await game.RunAsync();
            Console.WriteLine("Thanks for playing!");
        }
    }
}
