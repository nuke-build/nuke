// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Serilog;
using Serilog.Events;

namespace Nuke.Common.Tooling;

public class LogErrorAsStandard : Attribute;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class LogLevelPattern(LogEventLevel level, [RegexPattern] string pattern) : Attribute
{
    public LogEventLevel Level { get; } = level;
    public string Pattern { get; } = pattern;
}

[AttributeUsage(AttributeTargets.Class)]
public class DefaultLogLevel(LogEventLevel level) : Attribute
{
    public LogEventLevel Level { get; } = level;
}

public abstract partial class ToolTasks
{
    protected internal virtual partial Action<OutputType, string> GetLogger(ToolOptions options)
    {
        if (options?.ProcessLogger != null)
            return options.ProcessLogger;

        var toolType = GetType();
        var levelProvider = toolType.GetCustomAttributes<LogLevelPattern>()
            .Select(x =>
            {
                var regex = new Regex(x.Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                return new Func<string, LogEventLevel?>(text => regex.IsMatch(text) ? x.Level : null);
            }).ToList();

        var errorAsStandard = toolType.HasCustomAttribute<LogErrorAsStandard>();
        var defaultLevel = toolType.GetCustomAttribute<DefaultLogLevel>()?.Level ?? LogEventLevel.Debug;

        return (type, text) =>
        {
            var patternLevel = levelProvider.Select(x => x.Invoke(text)).FirstOrDefault(x => x != null);
            if (patternLevel != null)
                Log.Write(patternLevel.Value, text);
            else if (type == OutputType.Err && !errorAsStandard)
                Log.Error(text);
            else
                Log.Write(defaultLevel, text);
        };
    }
}
