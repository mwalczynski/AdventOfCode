namespace AdventOfCode2018.Day3
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Day;
    using Readers;

    public class Day3Task2 : BaseDay
    {
        private readonly List<int>[,] _fabric;

        public Day3Task2(IInputReader reader) : base(reader)
        {
            _fabric = new List<int>[1000, 1000];
            for (var i = 0; i < _fabric.GetLength(0); i++)
            {
                for (var j = 0; j < _fabric.GetLength(1); j++)
                {
                    _fabric[i, j] = new List<int>();
                }
            }
        }

        public override string GetResult()
        {
            var input = GetCurrentTaskInput();
            var data = input.Select(i => Regex.Split(i, @"\D+")
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => int.Parse(x)));

            var claims = data.Select(x => new Claim(x.ToArray())).ToArray();

            foreach (var claim in claims)
            {
                for (int i = claim.Left; i < claim.Left + claim.Width; i++)
                {
                    for (int j = claim.Top; j < claim.Top + claim.Height; j++)
                    {
                        _fabric[i, j].Add(claim.Id);
                    }
                }
            }

            var fabricSquares = _fabric
                .Cast<List<int>>()
                .ToArray();

            var claimIds = claims.Select(x => x.Id);

            foreach (var claimId in claimIds)
            {
                var claimSquares = fabricSquares.Where(x => x.Contains(claimId));
                if (claimSquares.All(x => x.Count == 1))
                {
                    return claimId.ToString();
                }
            }

            return "Something went wrong";
        }
    }
}
