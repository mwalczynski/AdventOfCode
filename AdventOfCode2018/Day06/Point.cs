namespace AdventOfCode2018.Day6
{
    using System;

    public class Point
    {
        public int Index { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public int GetDistance(int x, int y)
        {
            return Math.Abs(this.X - x) + Math.Abs(this.Y - y);
        }
    }
}