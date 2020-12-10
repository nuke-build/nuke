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
            switch (type)
            {
                case OutputType.Std:
                    Logger.Normal(output);
                    break;
                case OutputType.Err:
                {
                    if (output.StartsWith("npmWARN") || output.StartsWith("npm WARN"))
                        Logger.Warn(output);
                    else
                        Logger.Error(output);

                    break;
                }
            }
        }
    }
}
