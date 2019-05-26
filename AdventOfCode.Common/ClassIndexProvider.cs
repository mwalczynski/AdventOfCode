namespace AdventOfCode.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class ClassIndexProvider
    {
        public static string GetClassIndex(Type type)
        {
            var assemblyNumber = GetStringNumbers(type.Assembly.GetName().Name);
            var classNumber = GetStringNumbers(type.Name);
            assemblyNumber.AddRange(classNumber);
            var result = string.Join(";", assemblyNumber);
            return result;
        }

        private static List<int> GetStringNumbers(string className)
        {
            var numbers = Regexes.NumbersRegex.Matches(className)
                .Cast<Match>()
                .Select(m => int.Parse(m.Value))
                .ToList();

            return numbers;
        }
    }
}