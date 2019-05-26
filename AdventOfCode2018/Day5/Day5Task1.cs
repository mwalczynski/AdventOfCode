namespace AdventOfCode2018.Day5
{
    using System;
    using System.Linq;
    using AdventOfCode.Common;

    public class Day5Task1 : BaseDay
    {
        public override string GetResult(string[] input)
        {
            var data = input.Single();

            var index = 0;
            var currentDataLength = data.Length;
            while (index < currentDataLength - 1)
            {
                var first = data[index];
                var second = data[index + 1];

                if (AreTheSameWithOppositePolarities(first, second))
                {
                    data = data.Remove(index, 2);
                    currentDataLength = currentDataLength - 2;
                    index = Math.Max(0, index - 1);
                    continue;
                }

                index++;
            }

            var result = data.Length;
            return result.ToString();
        }

        private bool AreTheSameWithOppositePolarities(char first, char second)
        {
            int firstValue = first;
            int secondValue = second;

            var result = Math.Abs(firstValue - secondValue) == 32;
            return result;
        }
    }
}
