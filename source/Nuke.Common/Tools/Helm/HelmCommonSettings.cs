// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Helm
{
    public partial class HelmCommonSettings
    {
        internal Arguments CreateArguments()
        {
            return ConfigureProcessArguments(new Arguments());
        }

        public override Action<OutputType, string> ProcessCustomLogger { get; }
    }
}
