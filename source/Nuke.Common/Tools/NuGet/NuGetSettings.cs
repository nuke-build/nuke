// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools.NuGet
{
    [Serializable]
    public class NuGetSettings : ToolSettings
    {
        public override string ToolPath =>
            base.ToolPath
            ?? ToolPathResolver.TryGetEnvironmentExecutable("NUGET_EXE")
            ?? ToolPathResolver.GetPackageExecutable("NuGet.CommandLine", "nuget.exe");
    }
}
