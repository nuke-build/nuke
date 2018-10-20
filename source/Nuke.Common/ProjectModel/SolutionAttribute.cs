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
    /// <inheritdoc cref="InjectionAttributeBase"/>
    /// <summary>
    ///     Injects an instance of <see cref="Solution"/>. The solution path is resolved in the following order:
    ///     <ul>
    ///         <li>From command-line arguments (e.g., <c>-solution path/to/solution.sln</c>)</li>
    ///         <li>From environment variables (e.g., <c>SOLUTION=path/to/solution.sln</c>)</li>
    ///         <li>From the constructor argument</li>
    ///         <li>From the <c>.nuke</c> configuration file</li>
    ///     </ul>
    ///     <inheritdoc cref="InjectionAttributeBase"/>
    /// </summary>
    /// <example>
    ///     <code>
    /// [Solution("common.sln")] readonly Solution Solution;
    /// Target FooBar => _ => _
    ///     .Executes(() =>
    ///     {
    ///         Logger.Log($"File: {Solution}");
    ///         Logger.Log($"Directory: {Solution.Directory}");
    ///         Logger.Log($"Projects: {Solution.AllProjects.Select(x => x.Name).JoinComma()}");
    ///     });
    ///     </code>
    /// </example>
    [PublicAPI]
    [UsedImplicitly(ImplicitUseKindFlags.Assign)]
    public class SolutionAttribute : ParameterAttribute
    {
        private readonly string _solutionFileRootRelativePath;

        [Obsolete("With the next release the " + NukeBuild.ConfigurationFileName + " configuration file will not longer be used to " +
                  "determine the solution file. Instead, pass the root-relative path to the " + nameof(SolutionAttribute) + ".")]
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
        
        [CanBeNull]
        public static string Configuration { get; set; }

        [CanBeNull]
        public static string TargetFramework { get; set; }
        
        public override object GetValue(string memberName, Type memberType, Type buildType)
        {
            return ProjectModelTasks.ParseSolution(
                GetSolutionFile(memberName),
                Configuration,
                TargetFramework);
        }
        
        // TODO: allow wildcard matching? [Solution("nuke-*.sln")] -- no globbing?
        // TODO: for just [Solution] without parameter being passed, do wildcard search?
        private string GetSolutionFile(string memberName)
        {
            var parameter = ParameterService.Instance.GetParameter<string>(memberName);
            if (parameter != null)
            {
                return PathConstruction.HasPathRoot(parameter) 
                    ? parameter :
                    PathConstruction.Combine(EnvironmentInfo.WorkingDirectory, parameter);
            }

            if (_solutionFileRootRelativePath != null)
                return PathConstruction.Combine(NukeBuild.Instance.RootDirectory, _solutionFileRootRelativePath);

            return GetSolutionFileFromConfigurationFile();
        }

        private string GetSolutionFileFromConfigurationFile()
        {
            var nukeFile = Path.Combine(NukeBuild.Instance.RootDirectory, NukeBuild.ConfigurationFileName);
            ControlFlow.Assert(File.Exists(nukeFile), $"File.Exists({NukeBuild.ConfigurationFileName})");

            var solutionFileRelative = File.ReadAllLines(nukeFile)[0];
            ControlFlow.Assert(!solutionFileRelative.Contains(value: '\\'), $"{NukeBuild.ConfigurationFileName} must use unix-styled separators");

            var solutionFile = Path.GetFullPath(Path.Combine(NukeBuild.Instance.RootDirectory, solutionFileRelative));
            ControlFlow.Assert(File.Exists(solutionFile), "File.Exists(solutionFile)");

            return (PathConstruction.AbsolutePath) solutionFile;
        }
    }
}
