// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Execution;

namespace Nuke.Common.ProjectModel
{
    /// <inheritdoc />
    [PublicAPI]
    [UsedImplicitly(ImplicitUseKindFlags.Assign)]
    public class SolutionAttribute : StaticInjectionAttributeBase
    {
        private readonly string _solutionFileRootRelativePath;

        [Obsolete("With the next release the " + NukeBuild.ConfigurationFile + " configuration file will not longer be used to " +
                  "determine the solution file. Instead, pass the root-relative path to the " + nameof(SolutionAttribute) + ".")]
        public SolutionAttribute()
            :this(solutionFileRootRelativePath: null)
        {
        }

        public SolutionAttribute(string solutionFileRootRelativePath)
        {
            _solutionFileRootRelativePath = solutionFileRootRelativePath;
        }
        
        [CanBeNull]
        public static string Configuration { get; set; }

        [CanBeNull]
        public static string TargetFramework { get; set; }

        public static Solution Value { get; private set; }

        [CanBeNull]
        public override object GetStaticValue()
        {
            var solutionFile = _solutionFileRootRelativePath != null
                ? Path.Combine(NukeBuild.Instance.RootDirectory, _solutionFileRootRelativePath)
#pragma warning disable 618
                : NukeBuild.Instance.SolutionFile;
#pragma warning restore 618
            
            return Value = Value ??
                           ProjectModelTasks.ParseSolution(
                               solutionFile,
                               Configuration ?? NukeBuild.Instance.Configuration,
                               TargetFramework);
        }
    }
}
