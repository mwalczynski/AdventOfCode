using System;

namespace AdventOfCode2018
{
    using System.Reflection;
    using System.Text.RegularExpressions;
    using Autofac;
    using Day;
    using Readers;

    public class ContainerBuilderFactory
    {
        public static IContainer Build()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<InputReader>().As<IInputReader>();

            containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => Regex.IsMatch(t.Name, "Day\\d+Task[12]"))
                .As<IDay>();

            var container = containerBuilder.Build();
            return container;
        }
    }
}
