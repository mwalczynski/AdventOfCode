namespace AdventOfCode2018.Day3
{
    using System.Linq;
    using System.Text.RegularExpressions;
    using Day;
    using Readers;

    public class Day3Task1 : BaseDay
    {
        private readonly int[,] _fabric = new int[1000, 1000];

        public Day3Task1(IInputReader reader) : base(reader)
        {
        }

        public override string GetResult()
        {
            var input = GetCurrentTaskInput();
            var data = input.Select(i => Regex.Split(i, @"\D+")
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => int.Parse(x)));

            var claims = data.Select(x => new Claim(x.ToArray()));

            foreach (var claim in claims)
            {
                for (int i = claim.Left; i < claim.Left + claim.Width; i++)
                {
                    for (int j = claim.Top; j < claim.Top + claim.Height; j++)
                    {
                        _fabric[i, j]++;
                    }
                }
            }

            var result = _fabric
                .Cast<int>()
                .Count(x => x > 1);

            return result.ToString();
        }
    }
}
