namespace AdventOfCode.Common
{
    using System;
    using System.Reflection;
    using Autofac;
    using Module = Autofac.Module;

    public class DayAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var year = Assembly.GetAssembly(this.GetType()).GetName().Name.GetStringNumbers()[0];

            builder.RegisterAssemblyTypes(Assembly.GetAssembly(this.GetType()))
                .AssignableTo<BaseDay>()
                .Named<BaseDay>(t => $"{year};{string.Join(";", t.Name.GetStringNumbers())}");
        }
    }
}
