// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Core;

namespace Nuke.Common.Tools.InspectCode
{
    partial class InspectCodeSettings
    {
        private string GetPackageExecutable ()
        {
            return EnvironmentInfo.Is64Bit ? "inspectcode.exe" : "inspectcode.x86.exe";
        }
    }
}
