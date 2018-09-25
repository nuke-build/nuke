// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Execution;
using Nuke.Common.IO;

namespace Nuke.Common.ProjectModel
{
    /// <inheritdoc />
    [PublicAPI]
    [UsedImplicitly(ImplicitUseKindFlags.Assign)]
    public class SolutionAttribute : ParameterAttribute
    {
        private readonly string _solutionFileRootRelativePath;

        [Obsolete("With the next release the " + NukeBuild.ConfigurationFile + " configuration file will not longer be used to " +
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
        
#pragma warning disable 618

        public override object GetValue(string memberName, Type memberType)
        {
            return ProjectModelTasks.ParseSolution(
                GetSolutionFile(memberName),
                Configuration ?? NukeBuild.Instance.Configuration,
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

            return NukeBuild.Instance.SolutionFile;
        }
#pragma warning restore 618
    }
}
