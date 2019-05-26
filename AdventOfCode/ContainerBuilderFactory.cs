namespace AdventOfCode
{
    using System;
    using System.Linq;
    using AdventOfCode2018;
    using Autofac;
    using Autofac.Features.AttributeFilters;
    using Common.Readers;

    public class ContainerBuilderFactory
    {
        public static IContainer Build()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new AutofacModule());

            containerBuilder.Register(c => Config.Year).Keyed<int>(Config.YearConfigKey);
            containerBuilder.RegisterType<DaysManager>().As<IDaysManager>().WithAttributeFiltering();
            containerBuilder.RegisterType<InputReader>().As<IInputReader>();

            var container = containerBuilder.Build();
            return container;
        }
    }
}
