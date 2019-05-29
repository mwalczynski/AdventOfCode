namespace AdventOfCode
{
    using Autofac.Features.AttributeFilters;
    using Autofac.Features.Indexed;
    using Common;
    using Common.Readers;

    public class DaysManager : IDaysManager
    {
        private readonly IIndex<string, BaseDay> _tasks;
        private readonly IInputReader _reader;
        private readonly int _year;

        public DaysManager(IIndex<string, BaseDay> tasks, IInputReader reader, [KeyFilter(Config.YearConfigKey)] int year)
        {
            _tasks = tasks;
            _reader = reader;
            _year = year;
        }

        public string GetResult(int dayNumber, int taskNumber)
        {
            var taskIdentifier = $"{dayNumber};{taskNumber}";
            var day = _tasks[taskIdentifier];
            var isTaskNumberNecessary = day.IsTaskNumberNecessary;
            var input = GetTaskInput(_year, dayNumber, taskNumber, isTaskNumberNecessary);
            var result = day.GetResult(input);
            return result;
        }

        private string[] GetTaskInput(int year, int dayNumber, int taskNumber, bool isTaskNumberNecessary)
        {
            var data = isTaskNumberNecessary ?
                _reader.GetInput(year, dayNumber, taskNumber) :
                _reader.GetInput(year, dayNumber);

            var input = data.Split('\n');
            return input;
        }
    }
}
