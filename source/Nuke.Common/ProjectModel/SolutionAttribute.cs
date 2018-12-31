// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Execution;
using Nuke.Common.IO;

namespace Nuke.Common.ProjectModel
{
    /// <summary>
    ///     Injects an instance of <see cref="Solution"/>. The solution path is resolved in the following order:
    ///     <ul>
    ///         <li>From command-line arguments (e.g., <c>-[MemberName] path/to/solution.sln</c>)</li>
    ///         <li>From environment variables (e.g., <c>[MemberName]=path/to/solution.sln</c>)</li>
    ///         <li>From the constructor argument</li>
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
        private readonly string _solutionFileRootRelativePath;

        public SolutionAttribute()
            : this(solutionFileRootRelativePath: null)
        {
        }

        public SolutionAttribute(string solutionFileRootRelativePath)
            : base("Path to a solution file that is automatically loaded."
                   + (solutionFileRootRelativePath != null ? $" Default is {solutionFileRootRelativePath}." : string.Empty))
        {
            _solutionFileRootRelativePath = solutionFileRootRelativePath;
        }
        
        public override object GetValue(MemberInfo member, object instance)
        {
            return ProjectModelTasks.ParseSolution(GetSolutionFile(member.Name));
        }
        
        // TODO: allow wildcard matching? [Solution("nuke-*.sln")] -- no globbing?
        // TODO: for just [Solution] without parameter being passed, do wildcard search?
        private string GetSolutionFile(string memberName)
        {
            var parameterValue = ParameterService.Instance.GetParameter<PathConstruction.AbsolutePath>(memberName);
            if (parameterValue != null)
                return parameterValue;

            if (_solutionFileRootRelativePath != null)
                return PathConstruction.Combine(NukeBuild.RootDirectory, _solutionFileRootRelativePath);

            return GetSolutionFileFromConfigurationFile();
        }

        private string GetSolutionFileFromConfigurationFile()
        {
            var nukeFile = Path.Combine(NukeBuild.RootDirectory, Constants.ConfigurationFileName);
            ControlFlow.Assert(File.Exists(nukeFile), $"File.Exists({nukeFile})");

            var solutionFileRelative = File.ReadAllLines(nukeFile).ElementAtOrDefault(0);
            ControlFlow.Assert(solutionFileRelative != null && !solutionFileRelative.Contains(value: '\\'),
                $"First line of {Constants.ConfigurationFileName} must provide solution path using UNIX separators");

            var solutionFile = Path.GetFullPath(Path.Combine(NukeBuild.RootDirectory, solutionFileRelative));
            ControlFlow.Assert(File.Exists(solutionFile),
                $"Solution file '{solutionFile}' provided via {Constants.ConfigurationFileName} does not exist.");

            return (PathConstruction.AbsolutePath) solutionFile;
        }
    }
}
