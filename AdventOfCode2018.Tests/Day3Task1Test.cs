namespace AdventOfCode2018.Tests
{
    using Day3;
    using FluentAssertions;
    using NUnit.Framework;

    class Day3Task1Test
    {
        [TestCase(new[] { "#123 @ 3,2: 5x4" }, 0)]
        [TestCase(new[] { "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2" }, 4)]
        public void Test(string[] input, int expected)
        {
            // arrange
            var day = new Day3Task1();

            // act
            var result = day.GetResult(input);

            // assert
            result.Should().Be(expected.ToString());
        }
    }
}
