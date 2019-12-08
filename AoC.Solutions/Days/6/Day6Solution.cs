using System.IO;
using System.Reflection;

namespace AoC.Solutions.Days.Six
{
    public class Day6Solution : ISolution
    {
        private readonly OrbitCountFinder finder;

        public Day6Solution()
        {
            finder = new OrbitCountFinder();
        }

        public string Solve()
        {
            var file = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "days/6/input.txt");
            var lines = File.ReadAllLines(file);

            return finder.GetOrbitTransfers(lines).ToString();
        }
    }
}