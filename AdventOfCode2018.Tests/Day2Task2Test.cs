namespace AdventOfCode2018.Tests
{
    using Day2;
    using FluentAssertions;
    using NUnit.Framework;

    class Day2Task2Test
    {
        [TestCase(new[] { "abcde", "fghij", "klmno", "pqrst", "fguij", "axcye", "wvxyz" }, "fgij")]
        public void Test(string[] input, string expected)
        {
            // arrange
            var day = new Day2Task2();

            // act
            var result = day.GetResult(input);

            // assert
            result.Should().Be(expected);
        }
    }
}
