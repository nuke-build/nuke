// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Pulumi
{
    public static partial class PulumiTasks
    {
        public static void CustomLogger(OutputType type, string text)
        {
            var output = text.TrimStart();

            if (type == OutputType.Std)
            {
                Logger.Normal(output);
                return;
            }

            if (output.StartsWith("warning:"))
                Logger.Warn(output);
            else
                Logger.Error(output);
        }
    }
}
