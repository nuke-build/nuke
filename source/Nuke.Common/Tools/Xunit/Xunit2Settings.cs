// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Core;
using Nuke.Core.Utilities;

namespace Nuke.Common.Tools.Xunit
{
    partial class Xunit2Settings
    {
        private string GetPackageExecutable()
        {
            return EnvironmentInfo.Is64Bit ? "xunit.console.exe" : "xunit.console.x86.exe";
        }
    }
}
