// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

namespace Nuke.Common.CI.SpaceAutomation
{
    public partial class SpaceAutomation
    {
        internal override string OutputTemplate => "[{Level:u3}] {Message:l}{NewLine}{Exception}";
    }
}
