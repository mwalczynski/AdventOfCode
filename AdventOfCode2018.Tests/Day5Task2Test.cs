namespace AdventOfCode2018.Tests
{
    using Day5;
    using FluentAssertions;
    using NUnit.Framework;

    class Day5Task2Test
    {
        [TestCase(new[] { "dabAcCaCBAcCcaDA" }, 4)]
        public void Test(string[] input, int expected)
        {
            // arrange
            var day = new Day5Task2();

            // act
            var result = day.GetResult(input);

            // assert
            result.Should().Be(expected.ToString());
        }
    }
}
