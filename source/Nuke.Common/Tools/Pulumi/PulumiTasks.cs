// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.Tooling;
using Serilog;

namespace Nuke.Common.Tools.Pulumi
{
    partial class PulumiTasks
    {
        public static void CustomLogger(OutputType type, string text)
        {
            var output = text.TrimStart();

            if (type == OutputType.Std)
            {
                Log.Debug(output);
                return;
            }

            if (output.StartsWith("warning:"))
                Log.Warning(output);
            else
                Log.Error(output);
        }
    }
}
