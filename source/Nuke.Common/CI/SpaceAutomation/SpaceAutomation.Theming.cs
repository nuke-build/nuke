// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.Execution;

namespace Nuke.Common.CI.SpaceAutomation
{
    public partial class SpaceAutomation
    {
        internal override string OutputTemplate => Logging.StandardOutputTemplate;
    }
}
