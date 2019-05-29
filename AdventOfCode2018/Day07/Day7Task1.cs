namespace AdventOfCode2018.Day7
{
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode.Common;

    public class Day7Task1 : BaseDay
    {
        public override string GetResult(string[] input)
        {
            var data = input.Select(i => (first: i[5], this, second: i[36])).ToArray();

            var firsts = data.Select(d => d.first).Distinct().ToArray();
            var seconds = data.Select(d => d.second).Distinct().ToArray();
            var allTasks = firsts.Concat(seconds).Distinct().ToArray();

            var successors = data.GroupBy(d => d.first).ToDictionary(grp => grp.Key, grp => grp.Select(x => x.second).ToList());
            var prerequisites = data.GroupBy(d => d.second).ToDictionary(grp => grp.Key, grp => grp.Select(x => x.first).ToList());

            var finishValues = allTasks.Except(firsts);
            foreach (var finishValue in finishValues)
            {
                successors.Add(finishValue, new List<char>());
            }

            var startingValues = allTasks.Except(seconds);
            var availableTasks = new SortedSet<char>(startingValues);

            var completedTasks = new List<char>();

            while (availableTasks.Any())
            {
                var currentTask = availableTasks.First();
                availableTasks.Remove(currentTask);
                completedTasks.Add(currentTask);

                var taskSuccessors = successors[currentTask];
                var readyTasks = taskSuccessors.Where(t => prerequisites[t].TrueForAll(x => completedTasks.Contains(x)));

                foreach (var readyTask in readyTasks)
                {
                    availableTasks.Add(readyTask);
                }
            }

            var result = new string(completedTasks.ToArray());
            return result;
        }
    }
}
