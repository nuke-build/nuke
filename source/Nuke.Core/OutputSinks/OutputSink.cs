// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core.BuildServers;
using Nuke.Core.Execution;

namespace Nuke.Core.OutputSinks
{
    public interface IOutputSink
    {
        void Write(string text);
        IDisposable WriteBlock(string text);

        void Trace(string text);
        void Info(string text);
        void Warn(string text, string details = null);
        void Error(string text, string details = null);

        void WriteSummary(IReadOnlyCollection<TargetDefinition> executionList);
    }

    internal static class OutputSink
    {
        internal static IOutputSink Instance { get; } = GetOutputSink(EnvironmentInfo.HostType);

        internal static IOutputSink GetOutputSink(HostType hostType)
        {
            switch (hostType)
            {
                case HostType.Bitrise:
                    return new BitriseOutputSink();
                case HostType.TeamCity:
                    return new TeamCityOutputSink(new TeamCity());
                case HostType.TeamServices:
                    return new TeamServicesOutputSink(new TeamServices());
                default:
                    return new ConsoleOutputSink();
            }
        }

        private static readonly List<Tuple<LogLevel, string>> s_severeMessages = new List<Tuple<LogLevel, string>>();

        public static void Write(string text)
        {
            Instance.Write(text);
        }

        public static IDisposable WriteBlock(string text)
        {
            return Instance.WriteBlock(text);
        }

        public static void Trace(string text)
        {
            if (NukeBuild.Instance?.LogLevel > LogLevel.Trace)
                return;

            Instance.Trace(text);
        }

        public static void Info(string text)
        {
            if (NukeBuild.Instance?.LogLevel > LogLevel.Information)
                return;

            Instance.Info(text);
        }

        public static void Warn(string text, string details = null)
        {
            if (NukeBuild.Instance?.LogLevel > LogLevel.Warning)
                return;

            s_severeMessages.Add(Tuple.Create(LogLevel.Warning, text));

            Instance.Warn(text, details);
        }

        public static void Error(string text, string details = null)
        {
            s_severeMessages.Add(Tuple.Create(LogLevel.Error, text));

            Instance.Error(text, details);
        }

        public static void WriteSummary(IReadOnlyCollection<TargetDefinition> executionList)
        {
            Write(string.Empty);

            if (s_severeMessages.Count > 0)
            {
                Write("Repeating warnings and errors:");


                foreach (var severeMessage in s_severeMessages)
                    switch (severeMessage.Item1)
                    {
                        case LogLevel.Warning:
                            Instance.Warn(severeMessage.Item2);
                            break;
                        case LogLevel.Error:
                            Instance.Error(severeMessage.Item2);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                Write(string.Empty);
            }

            Instance.WriteSummary(executionList);
        }
    }
}
