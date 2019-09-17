// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.IO;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    public static class ToolResolver
    {
        public static Tool GetPackageTool(string packageId, string packageExecutable, string version = null, string framework = null)
        {
            var toolPath = ToolPathResolver.GetPackageExecutable(packageId, packageExecutable, version, framework);
            return new ToolExecutor(toolPath).Execute;
        }

        [CanBeNull]
        public static Tool TryGetEnvironmentTool(string name)
        {
            var toolPath = ToolPathResolver.TryGetEnvironmentExecutable($"{name.ToUpperInvariant()}_EXE");
            if (toolPath == null)
                return null;

            return new ToolExecutor(toolPath).Execute;
        }

        public static Tool GetLocalTool(string absoluteOrRelativePath)
        {
            var toolPath = PathConstruction.HasPathRoot(absoluteOrRelativePath)
                ? absoluteOrRelativePath
                : Path.Combine(NukeBuild.RootDirectory, absoluteOrRelativePath);
            ControlFlow.Assert(File.Exists(toolPath), $"File.Exists({toolPath})");
            return new ToolExecutor(toolPath).Execute;
        }

        public static Tool GetPathTool(string name)
        {
            var toolPath = ToolPathResolver.GetPathExecutable(name);
            return new ToolExecutor(toolPath).Execute;
        }
    }
}
