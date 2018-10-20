// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Execution;

namespace Nuke.Common.Tooling
{
    /// <inheritdoc/>
    /// <summary>
    ///     Injects a delegate for process execution. The path to the executable is resolved in the following order:
    ///     <ul>
    ///         <li>From environment variables (e.g., <c>[MEMBER_NAME]_EXE=path</c>)</li>
    ///         <li>
    ///             From the <c>.csproj</c> or <c>packages.config</c> file using <c>packageId</c> and
    ///             <c>packageExecutable</c> to look up the NuGet package cache
    ///         </li>
    ///     </ul>
    ///     <inheritdoc/>
    /// </summary>
    /// <example>
    ///     <code>
    /// [PackageExecutable("NuGet.CommandLine", "nuget.exe")] readonly Tool NuGet;
    /// Target FooBar => _ => _
    ///     .Executes(() =>
    ///     {
    ///         var process = NuGet($"pack {ProjectFile}");
    ///         process.AssertZeroExitCode();
    ///     });
    ///     </code>
    /// </example>
    public class PackageExecutableAttribute : InjectionAttributeBase
    {
        private readonly string _packageId;
        private readonly string _packageExecutable;
        private readonly string _framework;

        public PackageExecutableAttribute(string packageId, string packageExecutable, string framework = null)
        {
            _packageId = packageId;
            _packageExecutable = packageExecutable;
            _framework = framework;
        }

        public override object GetValue(string memberName, Type memberType)
        {
            var toolPath =
                ToolPathResolver.TryGetEnvironmentExecutable($"{memberName.ToUpperInvariant()}_EXE") ??
                ToolPathResolver.GetPackageExecutable(_packageId, _packageExecutable, _framework);
            return new Tool(new ToolExecutor(toolPath).Execute);
        }
    }
}
