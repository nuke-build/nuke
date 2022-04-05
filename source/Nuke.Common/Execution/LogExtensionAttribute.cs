// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using JetBrains.Annotations;
using Serilog;

namespace Nuke.Common.Execution
{
    [PublicAPI]
    public interface ILogExtension
    {
        float Priority { get; }
        string ConsoleTemplate {get;}
        LoggerConfiguration Configure(LoggerConfiguration configuration, NukeBuild build);
    }

    [PublicAPI]
    [AttributeUsage(AttributeTargets.Class)]
    public class LogExtensionAttribute : Attribute, ILogExtension
    {
        public virtual float Priority {get; set;}
        public string ConsoleTemplate {get; set;}
        public virtual LoggerConfiguration Configure(LoggerConfiguration configuration, [CanBeNull] NukeBuild build)
        {
            return configuration;
        }
    }
}
