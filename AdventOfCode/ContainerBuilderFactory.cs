namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using Autofac;
    using Module = Autofac.Module;

    public class ContainerBuilderFactory
    {
        public static IContainer Build()
        {
            var containerBuilder = new ContainerBuilder();

            var assemblies = GetAdventOfCodeAssemblies();
            containerBuilder.RegisterAssemblyModules<Module>(assemblies);

            var container = containerBuilder.Build();
            return container;
        }

        private static Assembly[] GetAdventOfCodeAssemblies()
        {
            var entryAssemblyName = Assembly.GetEntryAssembly().GetName().Name;
            var regex = new Regex($@"{entryAssemblyName}\d*$");

            var files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll");

            var assemblies = files
                .Select(file => Assembly.LoadFrom(file))
                .Where(assembly => regex.IsMatch(assembly.GetName().Name))
                .ToArray();

            return assemblies;
        }
    }
}
