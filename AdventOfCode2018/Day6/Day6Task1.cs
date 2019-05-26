namespace AdventOfCode2018.Day6
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using AdventOfCode.Common;

    public class Day6Task1 : BaseDay
    {
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

            for (int x = 0; x < gridXSize; x++)
            {
                for (int y = 0; y < gridYSize; y++)
                {
                    grid[x, y] = GetNearestPoint(x, y, points);
                }
            }

            var pointsToExclude = new HashSet<int>();

            for (int x = 0; x < gridXSize; x++)
            {
                pointsToExclude.Add(grid[x, 0]);
                pointsToExclude.Add(grid[x, gridYSize - 1]);
            }

            for (int y = 0; y < gridYSize; y++)
            {
                pointsToExclude.Add(grid[0, y]);
                pointsToExclude.Add(grid[gridXSize - 1, y]);
            }

            var countedAreas = GetCountedAreas(grid);

            var areasToConsider = countedAreas.Where(ca => !pointsToExclude.Contains(ca.Key));

            var result = areasToConsider.Max(a => a.Value);

            return result.ToString();
        }

        private int GetNearestPoint(int x, int y, Point[] points)
        {
            var distances = points
                .Select(p => (nearestPoint: p.Index, distance: p.GetDistance(x, y)))
                .OrderBy(d => d.distance)
                .ToArray();

            if (distances[0].distance == distances[1].distance)
            {
                return 0;
            }

            return distances[0].nearestPoint;
        }

        private Dictionary<int, int> GetCountedAreas(int[,] grid)
        {
            var countedAreas = new Dictionary<int, int>();

            var gridXSize = grid.GetLength(0);
            var gridYSize = grid.GetLength(1);
            for (int x = 0; x < gridXSize; x++)
            {
                for (int y = 0; y < gridYSize; y++)
                {
                    var index = grid[x, y];
                    if (countedAreas.ContainsKey(index))
                    {
                        countedAreas[index]++;
                    }
                    else
                    {
                        countedAreas.Add(index, 1);
                    }
                }
            }

            return countedAreas;
        }
    }
}
