namespace AdventOfCode2018.Tests
{
    using Day5;
    using FluentAssertions;
    using NUnit.Framework;

    class Day5Task1Test
    {

        [TestCase(new[] { "aA" }, 0)]
        [TestCase(new[] { "abBA" }, 0)]
        [TestCase(new[] { "abAB" }, 4)]
        [TestCase(new[] { "aabAAB" }, 6)]
        [TestCase(new[] { "dabAcCaCBAcCcaDA" }, 10)]
        public void Test(string[] input, int expected)
        {
            // arrange
            var day = new Day5Task1();

            // act
            var result = day.GetResult(input);

            // assert
            result.Should().Be(expected.ToString());
        }
    }
}
