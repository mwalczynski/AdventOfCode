namespace AdventOfCode2018
{
    using System.Reflection;
    using AdventOfCode.Common;
    using Autofac;
    using Module = Autofac.Module;

    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => Regexes.TaskRegex.IsMatch(t.Name))
                .Named<BaseDay>(t => ClassIndexProvider.GetClassIndex(t));
        }
    }
}
