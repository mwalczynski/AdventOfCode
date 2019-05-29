namespace AdventOfCode2018.Day3
{
    using System.Collections.Generic;

    public class Claim
    {
        public Claim(int id, int left, int top, int width, int height)
        {
            Id = id;
            Left = left;
            Top = top;
            Width = width;
            Height = height;
        }

        public Claim(IReadOnlyList<int> p)
        {
            Id = p[0];
            Left = p[1];
            Top = p[2];
            Width = p[3];
            Height = p[4];
        }

        public int Id { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
