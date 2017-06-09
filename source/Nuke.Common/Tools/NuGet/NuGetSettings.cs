// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using Nuke.Core;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools.NuGet
{
    [Serializable]
    public class NuGetSettings : ToolSettings
    {
        public override string ToolPath => EnvironmentInfo.Variable("NUGET_EXE") 
            ?? Path.Combine(Build.Instance.TemporaryDirectory, "nuget.exe");
    }
}
