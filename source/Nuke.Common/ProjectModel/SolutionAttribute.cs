// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.ProjectModel
{
    /// <summary>
    ///     Injects an instance of <see cref="Solution"/>. The solution path is resolved in the following order:
    ///     <ul>
    ///         <li>From the constructor argument</li>
    ///         <li>From command-line arguments (e.g., <c>-[MemberName] path/to/solution.sln</c>)</li>
    ///         <li>From environment variables (e.g., <c>[MemberName]=path/to/solution.sln</c>)</li>
    ///         <li>From the <c>.nuke</c> configuration file</li>
    ///     </ul>
    /// </summary>
    /// <example>
    ///     <code>
    /// [Solution("common.sln")] readonly Solution Solution;
    ///     </code>
    /// </example>
    [PublicAPI]
    [UsedImplicitly(ImplicitUseKindFlags.Assign)]
    public class SolutionAttribute : ParameterAttribute
    {
        private readonly string _relativePath;

        public SolutionAttribute()
            : this(relativePath: null)
        {
        }

        public SolutionAttribute(string relativePath)
            : base("Path to a solution file that is automatically loaded."
                   + (relativePath != null ? $" Default is {relativePath}." : string.Empty))
        {
            _relativePath = relativePath;
        }

        public override bool List { get; set; }
        public bool GenerateProjects { get; set; }

        public override object GetValue(MemberInfo member, object instance)
        {
            return ProjectModelTasks.ParseSolution(GetSolutionFile(member));
        }

        // TODO: allow wildcard matching? [Solution("nuke-*.sln")] -- no globbing?
        // TODO: for just [Solution] without parameter being passed, do wildcard search?
        private string GetSolutionFile(MemberInfo member)
        {
            if (_relativePath != null)
                return PathConstruction.Combine(NukeBuild.RootDirectory, _relativePath);

            var solutionFile = EnvironmentInfo.GetParameter<AbsolutePath>(member);
            return solutionFile.NotNull(
                new[]
                {
                    $"No solution file defined for '{member.Name}'.",
                    $"Invoke: nuke --save-profile --{ParameterService.GetParameterDashedName(member)} <value>"
                }.JoinNewLine());
        }
    }
}
