// Copyright 2019 Maintainers of NUKE.
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
            return ConfigureArguments(new Arguments());
        }

        public override Action<OutputType, string> CustomLogger => throw new NotSupportedException();
    }
}
