using System.Linq;

namespace AoC.Solutions.Days.Four
{
    public class Day4Solution : ISolution
    {
        public string Solve()
        {
            var validator = new CombinationValidator();

            var start = 156218;
            var end = 652527;
            var count = end - start;

            var toValidate = Enumerable.Range(start, count).Select(i => i.ToString());
            var totalValid = toValidate.Where(i => validator.Validate(i));

            return totalValid.Count().ToString();
        }
    }
}