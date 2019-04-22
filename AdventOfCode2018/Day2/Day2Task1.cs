namespace AdventOfCode2018.Day2
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http.Headers;
    using Day;
    using Readers;

    public class Day2Task1 : BaseDay
    {
        public Day2Task1(IInputReader reader) : base(reader)
        {
        }

        public override string GetResult()
        {
            var input = GetInput();
            var data = input;

            var twos = 0;
            var threes = 0;

            foreach (var s in data)
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
