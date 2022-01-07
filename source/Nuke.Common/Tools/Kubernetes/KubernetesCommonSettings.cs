// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Kubernetes
{
    public partial class KubernetesCommonSettings
    {
        internal Arguments CreateArguments()
        {
            return ConfigureProcessArguments(new Arguments());
        }

        public override Action<OutputType, string> ProcessCustomLogger { get; }
    }
}
