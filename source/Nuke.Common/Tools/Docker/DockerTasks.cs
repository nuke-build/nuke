// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tooling;
using Serilog;

namespace Nuke.Common.Tools.Docker
{
    partial class DockerTasks
    {
        internal static void CustomLogger(OutputType type, string output)
        {
            switch (type)
            {
                case OutputType.Std:
                    Log.Debug(output);
                    break;
                case OutputType.Err:
                {
                    if (output.StartsWith("WARNING!"))
                        Log.Warning(output);
                    else
                        Log.Error(output);

                    break;
                }
            }
        }
    }
}
