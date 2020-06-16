// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Execution;
using Nuke.Common.ValueInjection;

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
    ///         var output = NuGet($"pack {ProjectFile}");
    ///     });
    ///     </code>
    /// </example>
    public class PackageExecutableAttribute : ValueInjectionAttributeBase
    {
        private readonly string _packageId;
        private readonly string _packageExecutable;

        [CanBeNull]
        public string Framework { get; set; }

        [CanBeNull]
        public string Version { get; set; }

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
            return ToolResolver.TryGetEnvironmentTool(member.Name) ??
                   ToolResolver.GetPackageTool(_packageId, _packageExecutable, Version, Framework);
        }
    }
}
