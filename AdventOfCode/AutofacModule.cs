namespace AdventOfCode
{
    using Autofac;
    using Autofac.Features.AttributeFilters;
    using Common.Readers;

    class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => Config.Year).Keyed<int>(Config.YearConfigKey);
            builder.RegisterType<DaysManager>().As<IDaysManager>().WithAttributeFiltering();
            builder.RegisterType<InputReader>().As<IInputReader>();
        }
    }
}
