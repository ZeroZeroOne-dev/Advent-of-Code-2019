using AoC.Solutions.Days.Four;
using Xunit;

namespace AoC.Tests.Days.Four
{
    public class CombinationValidatorTests
    {
        private readonly CombinationValidator validator;

        public CombinationValidatorTests()
        {
            this.validator = new CombinationValidator();
        }

        [Theory]
        [InlineData("112233", true)]
        [InlineData("123444", false)]
        [InlineData("111122", true)]
        [InlineData("123789", false)]
        public void Can_Validate_Combination(string combination, bool expected)
        {
            var isValid = this.validator.Validate(combination);

            Assert.Equal(expected, isValid);
        }
    }
}