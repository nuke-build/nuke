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
        private readonly string _suffix;
        private readonly AppVeyorImage[] _images;

        public AppVeyorAttribute(
            AppVeyorImage image,
            params AppVeyorImage[] images)
            : this(suffix: null, image, images)
        {
        }

        public AppVeyorAttribute(
            [CanBeNull] string suffix,
            AppVeyorImage image,
            params AppVeyorImage[] images)
        {
            _suffix = suffix;
            _images = new[] { image }.Concat(images).ToArray();
        }

        public override string IdPostfix => _suffix;

        public override Type HostType => typeof(AppVeyor);
        public override string ConfigurationFile => NukeBuild.RootDirectory / ConfigurationFileName;
        public override IEnumerable<string> GeneratedFiles => new[] { ConfigurationFile };
        private string ConfigurationFileName => _suffix != null ? $"appveyor.{_suffix}.yml" : "appveyor.yml";

        public override IEnumerable<string> RelevantTargetNames => InvokedTargets;
        public override IEnumerable<string> IrrelevantTargetNames => new string[0];

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
        public string[] Secrets { get; set; } = new string[0];

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
                       Artifacts = GetArtifacts(relevantTargets).ToArray(),
                       Secrets = GetSecrets()
                   };
        }

        private IEnumerable<string> GetArtifacts(IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            return relevantTargets
                .Select(x => x.ArtifactProducts)
                .SelectMany(x => x)
                .Select(x => NukeBuild.RootDirectory.GetUnixRelativePathTo(x).ToString());
        }

        protected AppVeyorBranches GetBranches()
        {
            if (BranchesOnly.Length == 0 && BranchesExcept.Length == 0)
                return null;

            return new AppVeyorBranches
                   {
                       Only = BranchesOnly,
                       Except = BranchesExcept
                   };
        }

        private Dictionary<string, string> GetSecrets()
        {
            return Secrets
                .Select(x => x.Split(':'))
                .ToDictionary(x => x.ElementAt(0).Trim(), x => x.ElementAt(1).Trim());
        }
    }
}
