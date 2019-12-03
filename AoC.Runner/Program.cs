using System;
using AoC.Solutions.Days.Two;

namespace AoC.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new OpCodeRunner();
            var output = solution.Solve();

            Console.WriteLine($"the output is {output}");
        }
    }
}
