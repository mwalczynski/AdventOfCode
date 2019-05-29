namespace AdventOfCode.Common
{
    using System.Reflection;
    using Autofac;
    using Module = Autofac.Module;

    public class DayAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(this.GetType()))
                .Where(t => Regexes.TaskRegex.IsMatch(t.Name))
                .Named<BaseDay>(t => string.Join(";", ClassIndexProvider.GetStringNumbers(t.Name)))
                .Keyed<BaseDay>(t => ClassIndexProvider.GetStringNumbers(t.Assembly.GetName().Name)[0]);
        }
    }
}
