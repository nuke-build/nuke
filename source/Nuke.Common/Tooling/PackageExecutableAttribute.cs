// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Execution;

namespace Nuke.Common.Tooling
{
    /// <summary>
    ///     Injects a delegate for process execution. The path to the executable is resolved in the following order:
    ///     <ul>
    ///         <li>From environment variables (e.g., <c>[MEMBER_NAME]_EXE=path</c>)</li>
    ///         <li>
    ///             From the <c>.csproj</c> or <c>packages.config</c> file using <c>packageId</c> and
    ///             <c>packageExecutable</c> to look up the NuGet package cache
    ///         </li>
    ///     </ul>
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

        [CanBeNull]
        public string Framework { get; set; }

        public PackageExecutableAttribute(string packageId, string packageExecutable)
            : this(packageId, packageExecutable32: packageExecutable, packageExecutable64: packageExecutable)
        {
        }

        public PackageExecutableAttribute(string packageId, string packageExecutable32, string packageExecutable64)
        {
            _packageId = packageId;
            _packageExecutable = EnvironmentInfo.Is32Bit ? packageExecutable32 : packageExecutable64;
        }

        public override object GetValue(MemberInfo member, object instance)
        {
            var toolPath = ToolPathResolver.TryGetEnvironmentExecutable($"{member.Name.ToUpperInvariant()}_EXE") ??
                           ToolPathResolver.GetPackageExecutable(_packageId, _packageExecutable, Framework);
            return new Tool(new ToolExecutor(toolPath).Execute);
        }
    }
}
