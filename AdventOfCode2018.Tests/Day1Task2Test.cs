namespace AdventOfCode2018.Tests
{
    using Day1;
    using FluentAssertions;
    using NUnit.Framework;

    class Day1Task2Test
    {
        [TestCase(new[] { "+1", "-1" }, 0)]
        [TestCase(new[] { "+3", "+3", "+4", "-2", "-4" }, 10)]
        [TestCase(new[] { "-6", "+3", "+8", "+5", "-6" }, 5)]
        [TestCase(new[] { "+7", "+7", "-2", "-7", "-4" }, 14)]
        public void Test(string[] input, int expected)
        {
            // arrange
            var day = new Day1Task2();

            // act
            var result = day.GetResult(input);

            // assert
            result.Should().Be(expected.ToString());
        }
    }
}
