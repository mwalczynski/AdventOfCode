namespace AdventOfCode2018.Day
{
    public interface IDay
    {
        int DayNumber { get; }
        int TaskNumber { get; }
        string[] GetInput(bool isTaskNumberNecessary = false);
        string GetResult();
    }
}
