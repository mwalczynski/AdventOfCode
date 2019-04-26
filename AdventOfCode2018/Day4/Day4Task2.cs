namespace AdventOfCode2018.Day4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Day;
    using Readers;

    public class Day4Task2 : BaseDay
    {
        private const string _wakeUpInfo = "wakes up";
        private const string _fallsAsleepInfo = "falls asleep";

        public Day4Task2(IInputReader reader) : base(reader)
        {
        }

        public override string GetResult()
        {
            var input = GetInput();
            var messages = input
                .Select(x => ParseInput(x))
                .OrderBy(x => x.Timestamp);

            var guardSleepingTimestamps = new Dictionary<int, List<(int From, int To)>>();

            var currentGuardId = 0;
            var currentSleepingTime = (From: (int?)null, To: (int?)null);

            foreach (var message in messages)
            {
                var numbers = Regex.Matches(message.Information, @"\d+").Select(x => int.Parse(x.Value)).ToArray();
                if (numbers.Any())
                {
                    currentGuardId = numbers.Single();
                    if (!guardSleepingTimestamps.ContainsKey(currentGuardId))
                    {
                        guardSleepingTimestamps.Add(currentGuardId, new List<(int From, int To)>());
                    }
                    continue;
                }

                if (message.Information == _fallsAsleepInfo && !currentSleepingTime.From.HasValue)
                {
                    currentSleepingTime.From = message.Timestamp.Minute;
                }
                else if (message.Information == _fallsAsleepInfo)
                {
                    currentSleepingTime.To = 60;
                    guardSleepingTimestamps[currentGuardId].Add((currentSleepingTime.From.Value, currentSleepingTime.To.Value - 1));

                    currentSleepingTime.From = message.Timestamp.Minute;
                    currentSleepingTime.To = null;
                }
                else if (message.Information == _wakeUpInfo)
                {
                    currentSleepingTime.To = message.Timestamp.Minute;
                    guardSleepingTimestamps[currentGuardId].Add((currentSleepingTime.From.Value, currentSleepingTime.To.Value - 1));

                    currentSleepingTime.From = null;
                    currentSleepingTime.To = null;
                }
            }

            var (guardId, mostFrequentAsleepMinute) = GetGuardWithMostFrequentlyAsleepMinute(guardSleepingTimestamps);
            var result = guardId * mostFrequentAsleepMinute;
            return result.ToString();
        }

        private (int GuardId, int MostFrequentAsleepMinute) GetGuardWithMostFrequentlyAsleepMinute(Dictionary<int, List<(int From, int To)>> guardSleepingTimestamps)
        {
            var minutes = Enumerable.Range(0, 60).ToArray();

            var guardWithMostFrequentlyAsleepMinute = guardSleepingTimestamps.Aggregate((l, c) =>
                GetMostFrequentlyAsleepMinuteWithCount(l.Value, minutes).Count >
                GetMostFrequentlyAsleepMinuteWithCount(c.Value, minutes).Count
                    ? l
                    : c);

            var guardId = guardWithMostFrequentlyAsleepMinute.Key;
            var mostFrequentAsleepMinute = GetMostFrequentlyAsleepMinuteWithCount(guardWithMostFrequentlyAsleepMinute.Value, minutes).Minute;

            return (guardId, mostFrequentAsleepMinute);
        }

        private (int Minute, int Count) GetMostFrequentlyAsleepMinuteWithCount(List<(int From, int To)> sleepingTimestamps, int[] minutes)
        {
            var mostAsleepMinute = minutes.Aggregate((l, c) =>
                sleepingTimestamps.Count(x => l >= x.From && l <= x.To) >
                sleepingTimestamps.Count(x => c >= x.From && c <= x.To)
                    ? l
                    : c);

            var count = sleepingTimestamps.Count(x => mostAsleepMinute >= x.From && mostAsleepMinute <= x.To);
            return (mostAsleepMinute, count);
        }

        private Record ParseInput(string input)
        {
            var parts = Regex.Split(input, @"(?<=\b])(.)").Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            var timestamp = ParseTimestamp(parts[0]);
            var info = parts[1].Trim();

            var record = new Record(timestamp, info);
            return record;
        }

        private DateTime ParseTimestamp(string toParse)
        {
            var timestampText = Regex.Match(toParse, @"(?<=\[)(.*?)(?=\])").Value;
            var parts = timestampText.Split(' ');
            var dateParts = parts[0].Split('-').Select(x => int.Parse(x)).ToArray();
            var timeParts = parts[1].Split(':').Select(x => int.Parse(x)).ToArray();

            var timestamp = new DateTime(dateParts[0], dateParts[1], dateParts[2], timeParts[0], timeParts[1], 0);
            return timestamp;
        }
    }
}
