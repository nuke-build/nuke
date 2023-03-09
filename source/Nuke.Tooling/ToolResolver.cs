// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    public static class ToolResolver
    {
        public static Tool GetTool(string toolPath)
        {
            Assert.FileExists(toolPath);
            return new ToolExecutor(toolPath).Execute;
        }

        public static Tool GetNuGetTool(string packageId, string packageExecutable, string version = null, string framework = null)
        {
            var toolPath = NuGetToolPathResolver.GetPackageExecutable(packageId, packageExecutable, version, framework);
            return GetTool(toolPath);
        }

        public static Tool GetNpmTool(string npmExecutable)
        {
            var toolPath = NpmToolPathResolver.GetNpmExecutable(npmExecutable);
            return GetTool(toolPath);
        }

        [CanBeNull]
        public static Tool TryGetEnvironmentTool(string name)
        {
            var toolPath = ToolPathResolver.TryGetEnvironmentExecutable($"{name.ToUpperInvariant()}_EXE");
            if (toolPath == null)
                return null;

            return GetTool(toolPath);
        }

        public static Tool GetPathTool(string name)
        {
            var toolPath = ToolPathResolver.GetPathExecutable(name);
            return GetTool(toolPath);
        }

        public static Tool GetEnvironmentOrPathTool(string name)
        {
            return TryGetEnvironmentTool(name) ?? GetPathTool(name);
        }
    }
}
