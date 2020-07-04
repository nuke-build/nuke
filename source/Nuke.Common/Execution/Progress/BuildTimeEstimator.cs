using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Execution.Progress
{
    public static class BuildTimeEstimator
    {
        private static AbsolutePath BuildTimeRecordFile => Constants.GetBuildTimeRecordFile(NukeBuild.RootDirectory);

        private const int NumberOfSamples = 5;

        private static Dictionary<string, List<TimeSpan>> TargetTimeSamples = new Dictionary<string, List<TimeSpan>>();

        public static void ParseRecordFile()
        {
            if (!File.Exists(BuildTimeRecordFile))
                return;

            var lines = File.ReadAllLines(BuildTimeRecordFile);
            foreach (var line in lines)
            {
                var tokens = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length < 2)
                    continue;

                var key = tokens.First();
                if (TargetTimeSamples.ContainsKey(key))
                    continue;

                var values = tokens
                    .Skip(1)
                    .Select(x => TimeSpan.TryParse(x, out var result) ? result : (TimeSpan?)null)
                    .WhereNotNull()
                    .ToList();

                if (!values.Any())
                    continue;

                TargetTimeSamples.Add(key, values);
            }
        }

        public static void WriteRecordFile()
        {
            var lines = new List<string>();
            foreach (var (key, value) in TargetTimeSamples)
            {
                lines.Add($"{key} {string.Join(" ", value)}");
            }
            File.WriteAllLines(BuildTimeRecordFile, lines);
        }

        public static TimeSpan? GetEstimateForTarget(string targetName)
        {
            TargetTimeSamples.TryGetValue(targetName, out var times);
            return times?.Mean();
        }

        public static void AddTimeSample(string targetName, TimeSpan executionTime)
        {
            if (!TargetTimeSamples.ContainsKey(targetName))
            {
                TargetTimeSamples.Add(targetName, new List<TimeSpan>(new[] { executionTime }));
                return;
            }

            var times = TargetTimeSamples[targetName];

            // Remove so that we have max. (NumberOfSamples - 1) cutting off at the end, because we insert a new value.
            if (times.Count >= NumberOfSamples)
                times.RemoveRange(NumberOfSamples - 1, times.Count - NumberOfSamples + 1);

            times.Insert(0, executionTime);
        }
    }
}
