using System;

namespace AdventOfCode
{
    using Autofac;
    using DaysManager;

    class Program
    {
        private static readonly IContainer Resolver = ContainerBuilderFactory.Build();

        static void Main()
        {
            var (dayNumber, taskNumber) = AskForTask();

            var dayManager = Resolver.Resolve<IDaysManager>();
            var result = dayManager.GetResult(dayNumber, taskNumber);

            Console.WriteLine($"(Result for day {dayNumber} and task {taskNumber}: {result}");
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
