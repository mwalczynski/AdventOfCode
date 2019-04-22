namespace AdventOfCode2018.Day
{
    using System.Linq;
    using System.Text.RegularExpressions;
    using Readers;

    public abstract class BaseDay : IDay
    {
        private readonly IInputReader _reader;

        private readonly Regex _numbersRegex = new Regex(@"\d+");

        protected BaseDay(IInputReader reader)
        {
            _reader = reader;
        }

        public int DayNumber
        {
            get
            {
                var numbers = GetClassNumbers();
                var day = numbers.First();
                return day;
            }
        }

        public int TaskNumber
        {
            get
            {
                var numbers = GetClassNumbers();
                var task = numbers.Last();
                return task;
            }
        }

        public string[] GetInput(bool isTaskNumberNecessary = false)
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

            var numbers = _numbersRegex.Matches(className)
                .Select(m => int.Parse(m.Value))
                .ToArray();

            return numbers;
        }

        public abstract string GetResult();
    }
}
