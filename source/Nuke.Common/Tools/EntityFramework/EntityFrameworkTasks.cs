// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.EntityFramework;

partial class EntityFrameworkTasks
{
    internal static string GetToolPath(string framework = null)
    {
        return NuGetToolPathResolver.GetPackageExecutable(
            packageId: "dotnet-ef",
            packageExecutable: "dotnet-ef.dll|dotnet-ef.exe",
            framework: framework);
    }
}
