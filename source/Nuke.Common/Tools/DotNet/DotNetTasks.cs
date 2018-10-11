// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.DotNet
{
    partial class DotNetRunSettings
    {
        private string GetApplicationArguments()
        {
            return ApplicationArguments;
        }
    }

    public static partial class DotNetTasks
    {
        internal static LogLevel ParseLogLevel(string arg)
        {
            var spaces = 0;
            for (var i = 0; i < arg.Length && spaces < 3; i++)
            {
                if (arg[i] == ' ')
                {
                    spaces++;
                    continue;
                }

                if (i >= 4 &&
                    'e' == arg[i - 4] &&
                    'r' == arg[i - 3] &&
                    'r' == arg[i - 2] &&
                    'o' == arg[i - 1] &&
                    'r' == arg[i])
                    return LogLevel.Error;

                if (i >= 6 &&
                    'w' == arg[i - 6] &&
                    'a' == arg[i - 5] &&
                    'r' == arg[i - 4] &&
                    'n' == arg[i - 3] &&
                    'i' == arg[i - 2] &&
                    'n' == arg[i - 1] &&
                    'g' == arg[i])
                    return LogLevel.Warning;
            }

            return LogLevel.Information;
        }
    }
}
