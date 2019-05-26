namespace AdventOfCode2018.Day7
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode.Common;

    public class Day7Task2 : BaseDay
    {
        public int NumberOfWorkers;
        public int BaseSecondsToCompleteTask;
        public char?[] Workers;

        public Day7Task2(int numberOfWorkers = 5, int baseSecondsToCompleteTask = 60)
        {
            this.NumberOfWorkers = numberOfWorkers;
            this.BaseSecondsToCompleteTask = baseSecondsToCompleteTask;
        }

        public override string GetResult(string[] input)
        {
            this.Workers = new char?[NumberOfWorkers];

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

            var timesToFinish = allTasks.ToDictionary(t => t, t => this.BaseSecondsToCompleteTask + t - 'A' + 1);

            var second = 0;
            while (availableTasks.Any() || this.Workers.Any(w => w.HasValue))
            {
                var freeWorkerIds = this.Workers.Select((w, index) => w is null ? index : -1).Where(i => i >= 0).ToArray();
                var numberOfTasksToStart = Math.Min(availableTasks.Count, freeWorkerIds.Length);

                for (int i = 0; i < numberOfTasksToStart; i++)
                {
                    var taskToStart = availableTasks.First();
                    availableTasks.Remove(taskToStart);

                    var freeWorker = freeWorkerIds[i];
                    this.Workers[freeWorker] = taskToStart;
                }

                var workingWorkers = this.Workers.Where(w => w.HasValue).Select(w => w.Value).ToList();
                var secondsToMove = workingWorkers.Select(w => timesToFinish[w]).Min();
                workingWorkers.ForEach(w => timesToFinish[w] -= secondsToMove);

                var finishedWorkers = workingWorkers.Where(w => timesToFinish[w] == 0).ToArray();

                foreach (var finishedTask in finishedWorkers)
                {
                    var taskSuccessors = successors[finishedTask];
                    var readyTasks = taskSuccessors.Where(t => prerequisites[t].TrueForAll(p => timesToFinish[p] == 0)).ToList();
                    readyTasks.ForEach(r => availableTasks.Add(r));
                }

                var finishedWorkersIds = this.Workers.Select((w, index) => w.HasValue ? timesToFinish[w.Value] == 0 ? index : -1 : -1).Where(i => i >= 0).ToArray();
                foreach (var finishedWorker in finishedWorkersIds)
                {
                    this.Workers[finishedWorker] = null;
                }

                second += secondsToMove;
            }

            return second.ToString();
        }
    }
}
