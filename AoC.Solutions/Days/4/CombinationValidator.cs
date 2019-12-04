using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC.Solutions.Days.Four
{
    public class CombinationValidator
    {
        private static readonly Regex dupeRegex = new Regex(@"(.)\1+");

        public bool Validate(string combination)
        {
            try
            {
                CheckDoubles(combination);
                CheckOrder(combination);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void CheckDoubles(string combination)
        {
            var matches = dupeRegex.Matches(combination);

            if (!matches.Cast<Match>().Any(m => m.Length == 2))
            {
                throw new Exception("No duplicates");
            }
        }

        private void CheckOrder(string combination)
        {
            var ordered = new string(combination.OrderBy(c => c).ToArray());
            if (combination != ordered)
            {
                throw new Exception("Not in ascending order");
            }
        }
    }
}