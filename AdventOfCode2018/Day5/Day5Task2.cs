namespace AdventOfCode2018.Day5
{
    using System;
    using System.Linq;
    using AdventOfCode.Common;

    public class Day5Task2 : BaseDay
    {
        public override string GetResult(string[] input)
        {
            var data = input.Single();

            var chars = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (char)i).ToArray();

            var charToRemove = chars
                .Aggregate((l, c) =>
                    ProducePolymer(data, l).Length >
                    ProducePolymer(data, c).Length
                        ? c
                        : l);

            var fullyReactedPolymer = ProducePolymer(data, charToRemove);
            var result = fullyReactedPolymer.Length;
            return result.ToString();
        }

        private string ProducePolymer(string data, char charToRemove)
        {
            var lowerCharToCompare = char.ToLower(charToRemove);
            var upperCharToCompare = char.ToUpper(charToRemove);
            var chars = data.Where(c => !(c == lowerCharToCompare || c == upperCharToCompare)).ToArray();
            var polymer = new string(chars);
            var fullyReactedPolymer = FullyReactPolymer(polymer);
            return fullyReactedPolymer;
        }

        private string FullyReactPolymer(string polymer)
        {
            var index = 0;
            var currentDataLength = polymer.Length;
            while (index < currentDataLength - 1)
            {
                var first = polymer[index];
                var second = polymer[index + 1];

                if (AreTheSameWithOppositePolarities(first, second))
                {
                    polymer = polymer.Remove(index, 2);
                    currentDataLength = currentDataLength - 2;
                    index = Math.Max(0, index - 1);
                    continue;
                }

                index++;
            }

            var result = polymer;
            return result;
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
