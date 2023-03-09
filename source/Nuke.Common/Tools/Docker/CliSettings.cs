// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Docker
{
    public partial class CliSettings
    {
        public Arguments CreateArguments()
        {
            return ConfigureProcessArguments(new Arguments());
        }

        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? throw new NotSupportedException();
    }
}
