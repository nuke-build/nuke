// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools.DotNet
{
    [Serializable]
    public class DotNetSettings : ToolSettings
    {
        public override string ToolPath =>
                base.ToolPath
                ?? ToolPathResolver.TryGetEnvironmentExecutable("DOTNET_EXE")
                ?? ToolPathResolver.GetPathExecutable("dotnet");
    }
}
