namespace AdventOfCode2018
{
    using System.Text.RegularExpressions;

    public static class Regexes
    {
        public static readonly Regex TaskRegex = new Regex(@"Day\d+Task[12]");
        public static readonly Regex NumbersRegex = new Regex(@"\d+");
    }
}
