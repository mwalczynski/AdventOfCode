namespace AdventOfCode2018.Readers
{
    public interface IInputReader
    {
        string GetInput(int day);
        string GetInput(int day, int task);
    }
}