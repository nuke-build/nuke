// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.IO;

namespace Nuke.Common.Tooling
{
    /// <summary>
    ///     Injects a delegate for process execution. The path relative to the root directory is passed as constructor argument.
    /// </summary>
    /// <example>
    ///     <code>
    /// [LocalTool("./tools/custom.exe")] readonly Tool Custom;
    /// Target FooBar => _ => _
    ///     .Executes(() =>
    ///     {
    ///         var output = Custom("test");
    ///     });
    ///     </code>
    /// </example>
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class LocalPathAttribute : ToolInjectionAttributeBase
    {
        private readonly string _absoluteOrRelativePath;

        public LocalPathAttribute(string absoluteOrRelativePath)
        {
            _absoluteOrRelativePath = absoluteOrRelativePath;
        }

        public LocalPathAttribute(string windowsPath, string unixPath)
        {
            _absoluteOrRelativePath = EnvironmentInfo.IsWin ? windowsPath : unixPath;
        }

        public override ToolRequirement GetRequirement(MemberInfo member)
        {
            return null;
        }

        public override object GetValue(MemberInfo member, object instance)
        {
            var toolPath = PathConstruction.HasPathRoot(_absoluteOrRelativePath)
                ? _absoluteOrRelativePath
                : Path.Combine(Build.RootDirectory, _absoluteOrRelativePath);
            return ToolResolver.GetTool(toolPath);
        }
    }

    [Obsolete($"Use {nameof(LocalPathAttribute)} instead")]
    public class LocalExecutableAttribute : LocalPathAttribute
    {
        public LocalExecutableAttribute(string absoluteOrRelativePath)
            : base(absoluteOrRelativePath)
        {
        }
    }
}
