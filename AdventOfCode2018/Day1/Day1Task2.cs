namespace AdventOfCode2018.Day1
{
    using System.Collections.Generic;
    using System.Linq;
    using Day;
    using Readers;

    public class Day1Task2 : BaseDay
    {
        public Day1Task2(IInputReader reader) : base(reader)
        {
        }

        public override string GetResult()
        {
            var input = GetInput();
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
