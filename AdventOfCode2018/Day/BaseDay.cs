namespace AdventOfCode2018.Day
{
    using System.Linq;
    using Readers;

    public abstract class BaseDay : IDay
    {
        private readonly IInputReader _reader;

        protected BaseDay(IInputReader reader)
        {
            _reader = reader;
        }

        protected int DayNumber
        {
            get
            {
                var numbers = GetClassNumbers();
                var day = numbers.First();
                return day;
            }
        }

        protected int TaskNumber
        {
            get
            {
                var numbers = GetClassNumbers();
                var task = numbers.Last();
                return task;
            }
        }

        protected string[] GetCurrentTaskInput(bool isTaskNumberNecessary = false)
        {
            var data = isTaskNumberNecessary ?
                _reader.GetInput(DayNumber, TaskNumber) :
                _reader.GetInput(DayNumber);

            var input = data.Split('\n');
            return input;
        }

        private int[] GetClassNumbers()
        {
            var className = GetType().Name;

            var numbers = Regexes.NumbersRegex.Matches(className)
                .Select(m => int.Parse(m.Value))
                .ToArray();

            return numbers;
        }

        public abstract string GetResult();
    }
}
