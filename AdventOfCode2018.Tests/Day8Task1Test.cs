namespace AdventOfCode2018.Tests
{
    using Day8;
    using FluentAssertions;
    using NUnit.Framework;

    class Day8Task1Test
    {
        [TestCase(new[]
        {
            "2", "3", "0", "3", "10", "11", "12", "1", "1", "0", "1", "99", "2", "1", "1", "2"
        }, 138)]
        public void Test(string[] input, int expected)
        {
            // arrange
            var day = new Day8Task1();

            // act
            var result = day.GetResult(input);

            // assert
            result.Should().Be(expected.ToString());
        }
    }
}
