namespace AdventOfCode2018.Tests
{
    using Day7;
    using FluentAssertions;
    using NUnit.Framework;

    class Day7Task1Test
    {
        [TestCase(new[] {
            "Step C must be finished before step A can begin.",
            "Step C must be finished before step F can begin.",
            "Step A must be finished before step B can begin.",
            "Step A must be finished before step D can begin.",
            "Step B must be finished before step E can begin.",
            "Step D must be finished before step E can begin.",
            "Step F must be finished before step E can begin."
        }, "CABDFE")]
        public void Test(string[] input, string expected)
        {
            // arrange
            var day = new Day7Task1();

            // act
            var result = day.GetResult(input);

            // assert
            result.Should().Be(expected);
        }
    }
}
