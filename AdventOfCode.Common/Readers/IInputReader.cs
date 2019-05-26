namespace AdventOfCode.Common.Readers
{
    public interface IInputReader
    {
        string GetInput(int year, int day);
        string GetInput(int year, int day, int task);
    }
}