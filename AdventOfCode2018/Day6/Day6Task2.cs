namespace AdventOfCode2018.Day6
{
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode.Common;

    public class Day6Task2 : BaseDay
    {
        public int Threshold { get; set; } = 10000;

        public override string GetResult(string[] input)
        {
            var data = input.Select(i =>
                    i.Split(',')
                        .Select(x => int.Parse(x))
                        .ToArray())
                .ToArray();

            var minX = data.Min(d => d[0]);
            var minY = data.Min(d => d[1]);

            var points = data.Select((d, index) => new Point()
            {
                Index = index + 1,
                X = d[0] - minX + 1,
                Y = d[1] - minY + 1
            }).ToArray();

            var maxX = data.Max(d => d[0]);
            var maxY = data.Max(d => d[1]);

            var gridXSize = maxX - minX + 2;
            var gridYSize = maxY - minY + 2;
            var grid = new int[gridXSize, gridYSize];

            var regionSize = 0;
            for (int x = 0; x < gridXSize; x++)
            {
                for (int y = 0; y < gridYSize; y++)
                {
                    var totalDistance = points.Select(p => p.GetDistance(x, y)).Sum();
                    grid[x, y] = totalDistance;

                    if (totalDistance < this.Threshold)
                    {
                        regionSize++;
                    }
                }
            }

            return regionSize.ToString();
        }
    }
}
