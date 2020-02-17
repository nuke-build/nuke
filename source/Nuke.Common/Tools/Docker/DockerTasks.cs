using Nuke.Common.Tooling;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nuke.Common.Tools.Docker
{
    public static partial class DockerTasks
    {
        internal static void CustomLogger(OutputType type, string output)
        {
            if (type == OutputType.Err)
            {
                if (output.StartsWith("WARNING!"))
                {
                    Logger.Warn(output);
                    return;
                }

                Logger.Error(output);
                return;
            }

            Logger.Normal(output);
        }
    }
}
