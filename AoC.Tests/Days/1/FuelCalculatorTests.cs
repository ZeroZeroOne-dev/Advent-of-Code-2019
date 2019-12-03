using AoC.Solutions.Days.One;
using Xunit;

namespace AoC.Tests.Days.One
{
    public class FuelCalculatorTests
    {
        private readonly FuelCalculator calculator;

        public FuelCalculatorTests()
        {
            this.calculator = new FuelCalculator();
        }

        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 654)]
        [InlineData(100756, 33583)]
        public void Can_Calculate_Fuel(int input, int expected)
        {
            var output = this.calculator.Calculate(input);

            Assert.Equal(expected, output);
        }

    }
}