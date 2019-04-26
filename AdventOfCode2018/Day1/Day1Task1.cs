namespace AdventOfCode2018.Day1
{
    using System.Linq;
    using Day;
    using Readers;

    public class Day1Task1 : BaseDay
    {
        public Day1Task1(IInputReader reader) : base(reader)
        {
        }

        public override string GetResult()
        {
            var input = GetCurrentTaskInput();
            var numbers = input.Select(s => int.Parse(s));
            var result = numbers.Sum();
            return result.ToString();
        }
    }
}
