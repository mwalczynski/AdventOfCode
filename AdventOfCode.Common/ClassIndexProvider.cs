namespace AdventOfCode.Common
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class ClassIndexProvider
    {
        public static List<int> GetStringNumbers(string @string)
        {
            var numbers = Regexes.NumbersRegex.Matches(@string)
                .Cast<Match>()
                .Select(m => int.Parse(m.Value))
                .ToList();

            return numbers;
        }
    }
}