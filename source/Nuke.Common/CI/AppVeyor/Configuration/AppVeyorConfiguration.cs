// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.AppVeyor.Configuration
{
    public class AppVeyorConfiguration : AppVeyorConfigurationEntity
    {
        public AppVeyorImage[] Images { get; set; }
        public string BuildScript { get; set; }
        public AppVeyorService[] Services { get; set; }
        public AppVeyorBranches Branches { get; set; }
        public string[] Init { get; set; }
        public string[] Cache { get; set; }
        public string[] InvokedTargets { get; set; }
        public string[] Artifacts { get; set; }
        public bool SkipTags { get; set; }
        public bool SkipBranchesWithPullRequest { get; set; }
        public string OnlyCommitsMessage { get; set; }
        public string OnlyCommitsAuthor { get; set; }
        public string SkipCommitsMessage { get; set; }
        public string SkipCommitsAuthor { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock("image:"))
            {
                Images.ForEach(x => writer.WriteLine($"- {x.GetValue()}"));
                writer.WriteLine();
            }

            if (Services.Length > 0)
            {
                using (writer.WriteBlock("services:"))
                {
                    Services.ForEach(x => writer.WriteLine($"- {x.GetValue().ToLowerInvariant()}"));
                    writer.WriteLine();
                }
            }

            if (Branches != null)
            {
                using (writer.WriteBlock("branches:"))
                {
                    Branches.Write(writer);
                    writer.WriteLine();
                }
            }

            if (SkipTags ||
                SkipBranchesWithPullRequest ||
                OnlyCommitsMessage != null ||
                OnlyCommitsAuthor != null ||
                SkipCommitsMessage != null ||
                SkipCommitsAuthor != null)
            {
                if (SkipTags)
                    writer.WriteLine("skip_tags: true");
                if (SkipBranchesWithPullRequest)
                    writer.WriteLine("skip_branch_with_pr: true");

                if (OnlyCommitsMessage != null || OnlyCommitsAuthor != null)
                {
                    using (writer.WriteBlock("only_commits:"))
                    {
                        if (OnlyCommitsMessage != null)
                            writer.WriteLine($"message: {OnlyCommitsMessage}");
                        if (OnlyCommitsAuthor != null)
                            writer.WriteLine($"author: {OnlyCommitsAuthor}");
                    }
                }

                if (SkipCommitsMessage != null || SkipCommitsAuthor != null)
                {
                    using (writer.WriteBlock("skip_commits:"))
                    {
                        if (SkipCommitsMessage != null)
                            writer.WriteLine($"message: {SkipCommitsMessage}");
                        if (SkipCommitsAuthor != null)
                            writer.WriteLine($"author: {SkipCommitsAuthor}");
                    }
                }

                writer.WriteLine();
            }

            if (Init.Length > 0)
            {
                using (writer.WriteBlock("init:"))
                {
                    Init.ForEach(x => writer.WriteLine($"- {x}"));
                    writer.WriteLine();
                }
            }

            using (writer.WriteBlock("build_script:"))
            {
                writer.WriteLine($@"- ps: .\{BuildScript} {InvokedTargets.JoinSpace()}");
                writer.WriteLine();
            }

            if (Cache.Length > 0)
            {
                using (writer.WriteBlock("cache:"))
                {
                    Cache.ForEach(x => writer.WriteLine($"- {x}"));
                }
            }

            if (Artifacts.Length > 0)
            {
                using (writer.WriteBlock("artifacts:"))
                {
                    Artifacts.ForEach(x => writer.WriteLine($"- path: {x}"));
                }
            }
        }
    }
}
