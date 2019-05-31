namespace AdventOfCode.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class StringHelper
    {
        public static int[] GetStringNumbers(this string @string)
        {
            if (string.IsNullOrWhiteSpace(@string))
            {
                return Array.Empty<int>();
            }

            var numbers = Regexes.NumbersRegex.Matches(@string)
                .Cast<Match>()
                .Select(m => int.Parse(m.Value))
                .ToArray();

            return numbers;
        }
    }
}