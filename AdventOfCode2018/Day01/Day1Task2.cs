namespace AdventOfCode2018.Day1
{
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode.Common;

    public class Day1Task2 : BaseDay
    {
        public override string GetResult(string[] input)
        {
            var numbers = input.Select(s => int.Parse(s)).ToArray();

            var reachedFrequencies = new HashSet<int>();

            int index = 0;
            var frequency = 0;
            reachedFrequencies.Add(frequency);
            while (true)
            {
                frequency += numbers[index];

                if (reachedFrequencies.Contains(frequency))
                {
                    return frequency.ToString();
                }

                reachedFrequencies.Add(frequency);

                if (index == numbers.Length - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
            }
        }
    }
}
