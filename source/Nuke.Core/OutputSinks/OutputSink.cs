// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Core.Execution;

namespace Nuke.Core.OutputSinks
{
    public interface IOutputSink
    {
        void Write (string text);
        IDisposable WriteBlock (string text);

        void Trace (string text);
        void Info (string text);
        void Warn (string text, string details = null);
        void Error (string text, string details = null);

        void WriteSummary (IReadOnlyCollection<TargetDefinition> executionList);
    }

    internal static class OutputSink
    {
        private static readonly HashSet<string> s_warnings = new HashSet<string>();

        public static IOutputSink Instance =>
                TeamCityOutputSink.Instance
                ?? BitriseOutputSink.Instance
                ?? TeamServicesOutputSink.Instance
                ?? ConsoleOutputSink.Instance;
        
        public static void Write(string text)
        {
            Instance.Write(text);
        }

        public static IDisposable WriteBlock (string text)
        {
            return Instance.WriteBlock(text);
        }

        public static void Trace (string text)
        {
            if (NukeBuild.Instance?.LogLevel > LogLevel.Trace)
                return;

            Instance.Trace(text);
        }

        public static void Info (string text)
        {
            if (NukeBuild.Instance?.LogLevel > LogLevel.Information)
                return;

            Instance.Info(text);
        }

        public static void Warn (string text, string details = null)
        {
            if (NukeBuild.Instance?.LogLevel > LogLevel.Warning)
                return;

            s_warnings.Add(text);
            Instance.Warn(text, details);
        }

        public static void Error (string text, string details = null)
        {
            Instance.Error(text, details);
        }

        public static void WriteSummary (IReadOnlyCollection<TargetDefinition> executionList)
        {
            s_warnings.ToList().ForEach(x => Instance.Warn(x));
            Instance.WriteSummary(executionList);
        }
    }
}
