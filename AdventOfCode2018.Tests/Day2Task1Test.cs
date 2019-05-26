namespace AdventOfCode2018.Tests
{
    using Day2;
    using FluentAssertions;
    using NUnit.Framework;

    class Day2Task1Test
    {
        [TestCase(new[] { "abcdef", "bababc", "abbcde", "abcccd", "aabcdd", "abcdee", "ababab" }, 12)]
        public void Test(string[] input, int expected)
        {
            // arrange
            var day = new Day2Task1();

            // act
            var result = day.GetResult(input);

            // assert
            result.Should().Be(expected.ToString());
        }
    }
}
