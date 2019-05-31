namespace AdventOfCode
{
    using Autofac;
    using Autofac.Features.AttributeFilters;
    using Common.Readers;
    using DaysManager;

    class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => Config.Year).Keyed<int>(Config.YearConfigKey);
            builder.RegisterType<DaysManager.DaysManager>().As<IDaysManager>().WithAttributeFiltering();
            builder.RegisterType<InputReader>().As<IInputReader>();
        }
    }
}
