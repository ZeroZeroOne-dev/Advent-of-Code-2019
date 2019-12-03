using System;
using AoC.Solutions.Days.One;

namespace AoC.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new FuelCalculator();
            var output = solution.Solve();

            Console.WriteLine($"the output is {output}");
        }
    }
}
