// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Core;

namespace Nuke.Common.Tools.InspectCode
{
    partial class InspectCodeSettings
    {
        internal string GetPackageExecutable ()
        {
            return EnvironmentInfo.Is64Bit ? "inspectcode.exe" : "inspectcode.x86.exe";
        }
    }
}
