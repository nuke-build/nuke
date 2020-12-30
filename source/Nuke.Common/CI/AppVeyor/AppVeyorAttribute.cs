// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.AppVeyor
{
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AppVeyorAttribute : ConfigurationGeneratorAttributeBase
    {
        private readonly AppVeyorImage[] _images;

        public AppVeyorAttribute(AppVeyorImage image, params AppVeyorImage[] images)
        {
            _images = new[] { image }.Concat(images).ToArray();
        }

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

        public override IConfigurationGenerator GetConfigurationGenerator()
        {
            return new AppVeyorConfigurationGenerator(_images)
                   {
                       AutoGenerate = AutoGenerate,
                       Services = Services,
                       InvokedTargets = InvokedTargets,
                       BranchesOnly = BranchesOnly,
                       BranchesExcept = BranchesExcept,
                       SkipTags = SkipTags,
                       SkipBranchesWithPullRequest = SkipBranchesWithPullRequest,
                       OnlyCommitsMessage = OnlyCommitsMessage,
                       OnlyCommitsAuthor = OnlyCommitsAuthor,
                       SkipCommitsMessage = SkipCommitsMessage,
                       SkipCommitsAuthor = SkipCommitsAuthor,
                       Init = Init,
                       Cache = Cache
                   };
        }
    }
}
