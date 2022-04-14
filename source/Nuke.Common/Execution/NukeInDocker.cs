// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Execution
{
    public class NukeInDocker : Host
    {
        public static bool IsRunningNukeInDocker => true;
    }
}
