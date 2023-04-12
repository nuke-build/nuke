using System;
using System.Linq;
using Nuke.Common.IO;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Yarn;

public static partial class YarnTasks
{
    public static void CustomLogger(OutputType type, string output)
    {
        switch (type)
        {
            // Log standard output as Normal
            case OutputType.Std:
                Serilog.Log.Debug("{Output}", output);
                break;

            // Log output on err stream that contains 'warning' as Warning
            case OutputType.Err when output.Contains("warning", StringComparison.OrdinalIgnoreCase):
                Serilog.Log.Warning("{Output}", output);
                break;

            // Log diagnostic output on error stream as Trace
            case OutputType.Err
                when output.Contains("Building", StringComparison.OrdinalIgnoreCase) &&
                     output.Contains("for production", StringComparison.OrdinalIgnoreCase):
                Serilog.Log.Verbose("{Output}", output);
                break;

            // Log other output on err stream as Error
            case OutputType.Err:
                Serilog.Log.Error("{Output}", output);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }

    public static bool IsScriptAvailable(string name, AbsolutePath sourceDirectory)
    {
        var output = YarnRun(o => o.SetProcessWorkingDirectory(sourceDirectory)
            .DisableProcessLogOutput()
            .DisableProcessLogInvocation());
        var scripts = output.Where(o => o.Type == OutputType.Std).Select(o => o.Text);
        return scripts.Any(line => line.EndsWith($"- {name}"));
    }
}
