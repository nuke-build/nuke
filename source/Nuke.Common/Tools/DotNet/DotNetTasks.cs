// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.DotNet
{
    public class DotNetVerbosityMappingAttribute : VerbosityMappingAttribute
    {
        public DotNetVerbosityMappingAttribute()
            : base(typeof(DotNetVerbosity))
        {
            Quiet = nameof(DotNetVerbosity.Quiet);
            Minimal = nameof(DotNetVerbosity.Minimal);
            Normal = nameof(DotNetVerbosity.Normal);
            Verbose = nameof(DotNetVerbosity.Detailed);
        }
    }

    partial class DotNetRunSettings
    {
        private string GetApplicationArguments()
        {
            return ApplicationArguments;
        }
    }

    public static partial class DotNetTasks
    {
        internal static void CustomLogger(OutputType type, string output)
        {
            if (type == OutputType.Err)
            {
                Logger.Error(output);
                return;
            }

            var spaces = 0;
            for (var i = 0; i < output.Length && spaces < 3; i++)
            {
                if (output[i] == ' ')
                {
                    spaces++;
                    continue;
                }

                if (i >= 4 &&
                    'e' == output[i - 4] &&
                    'r' == output[i - 3] &&
                    'r' == output[i - 2] &&
                    'o' == output[i - 1] &&
                    'r' == output[i])
                {
                    Logger.Error(output);
                    return;
                }

                if (i >= 6 &&
                    'w' == output[i - 6] &&
                    'a' == output[i - 5] &&
                    'r' == output[i - 4] &&
                    'n' == output[i - 3] &&
                    'i' == output[i - 2] &&
                    'n' == output[i - 1] &&
                    'g' == output[i])
                {
                    Logger.Warn(output);
                    return;
                }
            }

            Logger.Normal(output);
        }
    }
}
