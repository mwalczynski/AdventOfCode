namespace AdventOfCode.Common
{
    public abstract class BaseDay
    {
        public bool IsTaskNumberNecessary = false;
        public abstract string GetResult(string[] input);
    }
}
