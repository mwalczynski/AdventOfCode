namespace AdventOfCode2018.Tests
{
    using Day1;
    using FluentAssertions;
    using NUnit.Framework;

    public class Day1Task1Test
    {
        [TestCase(new[] { "+1", "+1", "+1" }, 3)]
        [TestCase(new[] { "+1", "+1", "-2" }, 0)]
        [TestCase(new[] { "+1", "+1", "+1" }, 3)]
        public void Test(string[] input, int expected)
        {
            // arrange
            var day = new Day1Task1();

            // act
            var result = day.GetResult(input);

            // assert
            result.Should().Be(expected.ToString());
        }
    }
}