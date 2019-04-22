namespace AdventOfCode2018
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Autofac;
    using Day;
    using Microsoft.Extensions.DependencyInjection;

    class Program
    {
        private static readonly IContainer Resolver = ContainerBuilderFactory.Build();
        private static readonly IEnumerable<IDay> Days = Resolver.Resolve<IEnumerable<IDay>>();

        static void Main()
        {
            var (dayNumber, taskNumber) = GetDay();
            var day = Days.Single(d => d.DayNumber == dayNumber && d.TaskNumber == taskNumber);

            var result = day.GetResult();
            Console.WriteLine($"Result for day {dayNumber}: {result}");
        }

        private static (int, int) GetDay()
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
