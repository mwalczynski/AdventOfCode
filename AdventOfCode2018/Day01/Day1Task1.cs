namespace AdventOfCode2018.Day1
{
    using System.Linq;
    using AdventOfCode.Common;

    public class Day1Task1 : BaseDay
    {
        public override string GetResult(string[] input)
        {
            var numbers = input.Select(s => int.Parse(s));
            var result = numbers.Sum();
            return result.ToString();
        }
    }
}
