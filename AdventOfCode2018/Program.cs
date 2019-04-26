namespace AdventOfCode2018
{
    using System;
    using Autofac;
    using Autofac.Features.Indexed;
    using Day;

    class Program
    {
        private static readonly IContainer Resolver = ContainerBuilderFactory.Build();
        private static readonly IIndex<string, IDay> Tasks = Resolver.Resolve<IIndex<string, IDay>>();

        static void Main()
        {
            var (dayNumber, taskNumber) = AskForTask();
            var taskIdentifier = $"{dayNumber};{taskNumber}";
            var day = Tasks[taskIdentifier];

            var result = day.GetResult();
            Console.WriteLine($"Result for day {dayNumber} and task {taskNumber}: {result}");
        }

        private static (int, int) AskForTask()
        {
            Console.Write("Find result for day: ");
            var day = Console.ReadLine();
            var dayNumber = int.Parse(day);

            Console.Write("Task (1 or 2): ");
            var task = Console.ReadLine();
            var taskNumber = int.Parse(task);

            return (dayNumber, taskNumber);
        }
    }
}
