namespace AdventOfCode2018.Day2
{
    using System.Linq;
    using AdventOfCode.Common;

    public class Day2Task1 : BaseDay
    {
        public override string GetResult(string[] input)
        {
            var twos = 0;
            var threes = 0;

            foreach (var s in input)
            {
                var letters = s.ToCharArray()
                    .GroupBy(x => x)
                    .Select(x => new { Letter = x.Key, Count = x.Count() })
                    .ToArray();

                if (letters.Any(x => x.Count == 2))
                {
                    twos++;
                }

                if (letters.Any(x => x.Count == 3))
                {
                    threes++;
                }
            }

            var result = twos * threes;
            return result.ToString();
        }
    }
}
