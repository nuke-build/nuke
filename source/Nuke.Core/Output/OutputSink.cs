// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Core.Execution;

namespace Nuke.Core.Output
{
    public interface IOutputSink
    {
        void Trace (string text);
        void Info (string text);
        void Warn (string text, string details = null);
        void Fail (string text, string details = null);

        IDisposable WriteBlock (string text);

        void WriteSummary (IReadOnlyCollection<TargetDefinition> executionList);
    }

    internal static class OutputSink
    {
        private static readonly HashSet<string> s_warnings = new HashSet<string>();

        public static IOutputSink Instance =>
                TeamCityOutputSink.Instance
                ?? BitriseOutputSink.Instance
                ?? ConsoleOutputSink.Instance;

        public static void Trace (string text)
        {
            if (Build.Instance?.LogLevel > LogLevel.Trace)
                return;

            Instance.Trace(text);
        }

        public static void Info (string text)
        {
            if (Build.Instance?.LogLevel > LogLevel.Information)
                return;

            Instance.Info(text);
        }

        public static void Warn (string text, string details = null)
        {
            if (Build.Instance?.LogLevel > LogLevel.Warning)
                return;

            s_warnings.Add(text);
            Instance.Warn(text, details);
        }

        public static void Fail (string text, string details = null)
        {
            Instance.Fail(text, details);
        }

        public static IDisposable WriteBlock (string text)
        {
            return Instance.WriteBlock(text);
        }

        public static void WriteSummary (IReadOnlyCollection<TargetDefinition> executionList)
        {
            s_warnings.ToList().ForEach(x => Instance.Warn(x));
            Instance.WriteSummary(executionList);
        }
    }
}
