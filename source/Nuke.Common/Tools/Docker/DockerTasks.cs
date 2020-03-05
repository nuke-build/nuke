// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Docker
{
    public static partial class DockerTasks
    {
        internal static void CustomLogger(OutputType type, string output)
        {
            switch (type)
            {
                case OutputType.Std:
                    Logger.Normal(output);
                    break;
                case OutputType.Err:
                {
                    if (output.StartsWith("WARNING!"))
                        Logger.Warn(output);
                    else
                        Logger.Error(output);

                    break;
                }
            }
        }
    }
}
