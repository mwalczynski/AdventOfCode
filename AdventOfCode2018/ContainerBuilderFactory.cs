namespace AdventOfCode2018
{
    using System.Reflection;
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
                .Where(t => Regexes.TaskRegex.IsMatch(t.Name))
                .Named<IDay>(t => string.Join(";", Regexes.NumbersRegex.Matches(t.Name)));

            var container = containerBuilder.Build();
            return container;
        }
    }
}
