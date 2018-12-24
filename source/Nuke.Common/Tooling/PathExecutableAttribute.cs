// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using Nuke.Common.Execution;

namespace Nuke.Common.Tooling
{
    /// <summary>
    ///     Injects a delegate for process execution. The executable name is derived from the member name or can be
    ///     passed as constructor argument. The path to the executable is resolved in the following order:
    ///     <ul>
    ///         <li>From environment variables (e.g., <c>[NAME]_EXE=path</c>)</li>
    ///         <li>From the PATH variable using <c>which</c> or <c>where</c></li>
    ///     </ul>
    /// </summary>
    /// <example>
    ///     <code>
    /// [PathExecutable] readonly Tool Echo;
    /// Target FooBar => _ => _
    ///     .Executes(() =>
    ///     {
    ///         var process = Echo("test");
    ///         process.AssertZeroExitCode();
    ///     });
    ///     </code>
    /// </example>
    public class PathExecutableAttribute : InjectionAttributeBase
    {
        private readonly string _name;

        public PathExecutableAttribute(string name = null)
        {
            _name = name;
        }

        public override object GetValue(MemberInfo member, object instance)
        {
            var name = _name ?? member.Name;
            var toolPath = ToolPathResolver.TryGetEnvironmentExecutable($"{name.ToUpperInvariant()}_EXE") ??
                           ToolPathResolver.GetPathExecutable(name);
            return new Tool(new ToolExecutor(toolPath).Execute);
        }
    }
}
