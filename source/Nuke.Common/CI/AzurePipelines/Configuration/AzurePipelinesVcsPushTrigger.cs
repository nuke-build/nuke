// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Collections.Generic;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.AzurePipelines.Configuration
{
    [PublicAPI]
    public class AzurePipelinesVcsPushTrigger : ConfigurationEntity
    {
        public bool Disabled { get; set; }
        public bool? Batch { get; set; }
        public bool? AutoCancel { get; set; }
        public string[] BranchesInclude { get; set; }
        public string[] BranchesExclude { get; set; }
        public string[] TagsInclude { get; set; }
        public string[] TagsExclude { get; set; }
        public string[] PathsInclude { get; set; }
        public string[] PathsExclude { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            if (Disabled)
            {
                writer.WriteLine("none");
                return;
            }

            if (Batch.HasValue)
                writer.WriteLine($"batch: {Batch.ToString().ToLowerInvariant()}");

            if (AutoCancel.HasValue)
                writer.WriteLine($"autoCancel: {AutoCancel.ToString().ToLowerInvariant()}");

            if (BranchesInclude.Length > 0 || BranchesExclude.Length > 0)
            {
                using (writer.WriteBlock("branches:"))
                {
                    WriteInclusionsAndExclusions(writer, BranchesInclude, BranchesExclude);
                }
            }

            if (TagsInclude.Length > 0 || TagsExclude.Length > 0)
            {
                using (writer.WriteBlock("tags:"))
                {
                    WriteInclusionsAndExclusions(writer, TagsInclude, TagsExclude);
                }
            }

            if (PathsInclude.Length > 0 || PathsExclude.Length > 0)
            {
                using (writer.WriteBlock("paths:"))
                {
                    WriteInclusionsAndExclusions(writer, PathsInclude, PathsExclude);
                }
            }
        }

        private static void WriteInclusionsAndExclusions(
            CustomFileWriter writer,
            IReadOnlyCollection<string> inclusions,
            IReadOnlyCollection<string> exclusions)
        {
            if (inclusions.Count > 0)
            {
                using (writer.WriteBlock("include:"))
                {
                    inclusions.ForEach(x => writer.WriteLine($"- {x}"));
                }
            }

            if (exclusions.Count > 0)
            {
                using (writer.WriteBlock("exclude:"))
                {
                    exclusions.ForEach(x => writer.WriteLine($"- {x}"));
                }
            }
        }
    }
}
