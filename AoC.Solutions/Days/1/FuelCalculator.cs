using System;
using System.IO;
using System.Reflection;

namespace AoC.Solutions.Days.One
{
    public class FuelCalculator : ISolution
    {
        public int Calculate(int mass)
        {
            var fuel = GetMassFuel(mass);

            if (fuel > 0)
            {
                return fuel + Calculate(fuel);
            }

            if (fuel < 0)
            {
                fuel = 0;
            }

            return fuel;
        }

        // When you divide two integers, C# divides like a child in the third grade: it throws away any fractional remainder -> no rounding needed
        private int GetMassFuel(int mass) => mass / 3 - 2;

        public int CalculateFromFile(string file)
        {
            var total = 0;

            var lines = File.ReadAllLines(file);
            foreach (var line in lines)
            {
                if (int.TryParse(line, out var lineValue))
                {
                    total += this.Calculate(lineValue);
                }
            }

            return total;
        }

        public string Solve()
        {
            return CalculateFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "days/1/input.txt")).ToString();
        }
    }
}