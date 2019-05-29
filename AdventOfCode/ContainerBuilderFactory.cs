namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
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

            var assemblies = GetAssemblies().ToArray();
            containerBuilder.RegisterAssemblyModules<Module>(assemblies);

            var container = containerBuilder.Build();
            return container;
        }

        public static IEnumerable<Assembly> GetAssemblies()
        {
            var hashSet = new HashSet<string>();
            var stack = new Stack<Assembly>();

            var entryAssembly = Assembly.GetEntryAssembly();
            var entryAssemblyName = entryAssembly.GetName().Name;
            stack.Push(entryAssembly);

            var regex = new Regex($"{entryAssemblyName}\\d+");

            do
            {
                var assembly = stack.Pop();

                yield return assembly;

                foreach (var referencedAssembly in asse())
                {
                    if (!regex.IsMatch(referencedAssembly.Name)) continue;
                    if (hashSet.Contains(referencedAssembly.FullName)) continue;

                    stack.Push(Assembly.Load(referencedAssembly));
                    hashSet.Add(referencedAssembly.FullName);
                }

            }
            while (stack.Count > 0);
        }
    }
}
