// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Npm
{
    public static partial class NpmTasks
    {
        public static void CustomLogger(OutputType type, string output)
        {
            var outputLowered = output.ToLower();
            if (outputLowered.Contains("err!") || outputLowered.Contains("error:"))
                Logger.Error(output);
            else if (outputLowered.Contains("warn"))
                Logger.Warn(output);
            else
                Logger.Normal(output);
        }
    }
}
