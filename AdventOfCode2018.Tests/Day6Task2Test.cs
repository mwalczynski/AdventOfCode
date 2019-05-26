namespace AdventOfCode2018.Tests
{
    using Day6;
    using FluentAssertions;
    using NUnit.Framework;

    class Day6Task2Test
    {
        [TestCase(new[] {
            "1, 1",
            "1, 6",
            "8, 3",
            "3, 4",
            "5, 5",
            "8, 9"
        }, 32, 16)]
        public void Test(string[] input, int threshold, int expected)
        {
            // arrange
            var day = new Day6Task2 { Threshold = threshold };

            // act
            var result = day.GetResult(input);

            // assert
            result.Should().Be(expected.ToString());
        }
    }
}
