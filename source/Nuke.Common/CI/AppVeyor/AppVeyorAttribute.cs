// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
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

        public override HostType HostType => HostType.AppVeyor;
        public override string ConfigurationFile => NukeBuild.RootDirectory / "appveyor.yml";
        public override IEnumerable<string> GeneratedFiles => new[] { ConfigurationFile };

        public override IEnumerable<string> RelevantTargetNames => InvokedTargets;
        public override IEnumerable<string> IrrelevantTargetNames => Array.Empty<string>();

        public AppVeyorService[] Services { get; set; } = Array.Empty<AppVeyorService>();
        public string[] InvokedTargets { get; set; } = Array.Empty<string>();
        public string[] BranchesOnly { get; set; } = Array.Empty<string>();
        public string[] BranchesExcept { get; set; } = Array.Empty<string>();
        public bool SkipTags { get; set; }
        public bool SkipBranchesWithPullRequest { get; set; }
        public string OnlyCommitsMessage { get; set; }
        public string OnlyCommitsAuthor { get; set; }
        public string SkipCommitsMessage { get; set; }
        public string SkipCommitsAuthor { get; set; }
        public string[] Init { get; set; } = Array.Empty<string>();
        public string[] Cache { get; set; } = Array.Empty<string>();

        public override CustomFileWriter CreateWriter(StreamWriter streamWriter)
        {
            return new CustomFileWriter(streamWriter, indentationFactor: 2, "#");
        }

        public override ConfigurationEntity GetConfiguration(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            return new AppVeyorConfiguration
                   {
                       Images = _images,
                       BuildCmdPath = BuildCmdPath,
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
