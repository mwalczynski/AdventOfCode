namespace AdventOfCode
{
    using Autofac;
    using Autofac.Features.AttributeFilters;
    using Common.Readers;

    public class ContainerBuilderFactory
    {
        public static IContainer Build()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new AdventOfCode2016.AutofacModule());
            containerBuilder.RegisterModule(new AdventOfCode2018.AutofacModule());

            containerBuilder.Register(c => Config.Year).Keyed<int>(Config.YearConfigKey);
            containerBuilder.RegisterType<DaysManager>().As<IDaysManager>().WithAttributeFiltering();
            containerBuilder.RegisterType<InputReader>().As<IInputReader>();

            var container = containerBuilder.Build();
            return container;
        }
    }
}
