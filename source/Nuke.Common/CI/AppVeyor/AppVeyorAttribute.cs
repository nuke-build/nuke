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
    public class AppVeyorAttribute : ConfigurationAttributeBase
    {
        private readonly AppVeyorImage[] _images;

        public AppVeyorAttribute(AppVeyorImage image, params AppVeyorImage[] images)
        {
            _images = new[] { image }.Concat(images).ToArray();
        }

        private string ConfigurationFile => NukeBuild.RootDirectory / "appveyor.yml";

        protected override HostType HostType => HostType.AppVeyor;
        protected override IEnumerable<string> GeneratedFiles => new[] { ConfigurationFile };
        protected override IEnumerable<string> RelevantTargetNames => InvokedTargets;
        protected override IEnumerable<string> IrrelevantTargetNames => new string[0];

        public AppVeyorService[] Services { get; set; } = new AppVeyorService[0];
        public string[] InvokedTargets { get; set; } = new string[0];
        public string[] BranchesOnly { get; set; } = new string[0];
        public string[] BranchesExcept { get; set; } = new string[0];
        public bool SkipTags { get; set; }
        public bool SkipBranchesWithPullRequest { get; set; }
        public string OnlyCommitsMessage { get; set; }
        public string OnlyCommitsAuthor { get; set; }
        public string SkipCommitsMessage { get; set; }
        public string SkipCommitsAuthor { get; set; }
        public string[] Init { get; set; } = new string[0];
        public string[] Cache { get; set; } = new string[0];

        protected override CustomFileWriter CreateWriter()
        {
            return new CustomFileWriter(ConfigurationFile, indentationFactor: 2, "#");
        }

        protected override ConfigurationEntity GetConfiguration(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            return new AppVeyorConfiguration
                   {
                       Images = _images,
                       BuildScript = PowerShellScript,
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

        private IEnumerable<string> GetArtifacts(IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            return relevantTargets
                .Select(x => ArtifactExtensions.ArtifactProducts[x.Definition])
                .SelectMany(x => x)
                .Select(x => NukeBuild.RootDirectory.GetUnixRelativePathTo(x).ToString());
        }

        protected AppVeyorBranches GetBranches()
        {
            if (BranchesOnly.Length == 0 || BranchesExcept.Length == 0)
                return null;

            return new AppVeyorBranches
                   {
                       Only = BranchesOnly,
                       Except = BranchesExcept
                   };
        }
    }
}
