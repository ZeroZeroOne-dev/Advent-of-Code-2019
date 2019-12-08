using AoC.Solutions.Days.Six;
using Xunit;

namespace AoC.Tests.Days.Six
{
    public class OrbitCountFinderTests
    {
        private readonly OrbitCountFinder finder;

        public OrbitCountFinderTests()
        {
            finder = new OrbitCountFinder();
        }

        [Theory]
        [InlineData(new string[] { "COM)B", "B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "E)J", "J)K", "K)L" }, 42)]
        public void Can_Find_OrbitCount(string[] input, int expected)
        {
            var result = this.finder.GetTotalOrbits(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new string[] { "COM)B", "B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "E)J", "J)K", "K)L", "K)YOU", "I)SAN" }, 4)]
        public void Can_Find_Transfers(string[] input, int expected)
        {
            var result = this.finder.GetOrbitTransfers(input);

            Assert.Equal(expected, result);
        }

    }
}