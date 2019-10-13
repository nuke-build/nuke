// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.CI.AppVeyor.Configuration;
using Nuke.Common.Execution;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.IO.PathConstruction;

namespace Nuke.Common.CI.AppVeyor
{
    /// <summary>
    /// Interface according to the <a href="https://www.appveyor.com/docs/">official website</a>.
    /// </summary>
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class AppVeyorAttribute : ConfigurationGenerationAttributeBase
    {
        private readonly AppVeyorImage[] _images;

        public AppVeyorAttribute(AppVeyorImage image, params AppVeyorImage[] images)
        {
            _images = new[] { image }.Concat(images).ToArray();
        }

        public AppVeyorService[] Services { get; set; }
        public string[] InvokedTargets { get; set; }
        public string[] BranchesOnly { get; set; }
        public string[] BranchesExcept { get; set; }
        public bool SkipTags { get; set; }
        public bool SkipBranchesWithPullRequest { get; set; }
        public string OnlyCommitsMessage { get; set; }
        public string OnlyCommitsAuthor { get; set; }
        public string SkipCommitsMessage { get; set; }
        public string SkipCommitsAuthor { get; set; }
        public string[] Init { get; set; }
        public string[] Cache { get; set; }

        protected virtual string ConfigurationFile => NukeBuild.RootDirectory / "appveyor.yml";

        protected override IEnumerable<string> GeneratedFiles => new[] { ConfigurationFile };

        protected override HostType HostType => HostType.AppVeyor;

        protected override void Generate(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            var relevantTargets = InvokedTargets
                .SelectMany(x => ExecutionPlanner.GetExecutionPlan(executableTargets, new[] { x }))
                .Distinct().ToList();
            var configuration = GetConfiguration(build, relevantTargets);

            using var writer = new CustomFileWriter(ConfigurationFile, indentationFactor: 2);
            configuration.Write(writer);
        }

        protected virtual AppVeyorConfiguration GetConfiguration(NukeBuild build, List<ExecutableTarget> relevantTargets)
        {
            return new AppVeyorConfiguration
                   {
                       Images = _images,
                       Services = Services,
                       Branches = GetBranches(),
                       SkipTags = SkipTags,
                       SkipBranchesWithPullRequest = SkipBranchesWithPullRequest,
                       OnlyCommitsMessage = OnlyCommitsMessage,
                       OnlyCommitsAuthor = OnlyCommitsAuthor,
                       SkipCommitsMessage = SkipCommitsMessage,
                       SkipCommitsAuthor = SkipCommitsAuthor,
                       InvokedTargets = InvokedTargets,
                       Init = Init,
                       Cache = Cache,
                       Artifacts = GetArtifacts(relevantTargets).ToArray()
                   };
        }

        private IEnumerable<string> GetArtifacts(List<ExecutableTarget> relevantTargets)
        {
            return relevantTargets
                .Select(x => ArtifactExtensions.ArtifactProducts[x.Definition])
                .SelectMany(x => x)
                .Select(x => GetRelativePath(NukeBuild.RootDirectory, x));
        }

        protected AppVeyorBranches GetBranches()
        {
            if (BranchesOnly == null || BranchesExcept == null)
                return null;

            return new AppVeyorBranches
                   {
                       Only = BranchesOnly,
                       Except = BranchesExcept
                   };
        }
    }
}
