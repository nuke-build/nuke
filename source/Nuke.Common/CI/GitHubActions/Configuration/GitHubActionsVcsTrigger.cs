// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.GitHubActions.Configuration
{
    [PublicAPI]
    public class GitHubActionsVcsTrigger : GitHubActionsDetailedTrigger
    {
        public GitHubActionsTrigger Kind { get; set; }
        public string[] Branches { get; set; }
        public string[] BranchesIgnore { get; set; }
        public string[] Tags { get; set; }
        public string[] TagsIgnore { get; set; }
        public string[] IncludePaths { get; set; }
        public string[] ExcludePaths { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            writer.WriteLine($"{Kind.GetValue()}:");

            void WriteValue(string value)
                => writer.WriteLine($"- {value.SingleQuoteIfNeeded('.', '*', '!', '?', '+', '[', ']', '(', ')')}");

            using (writer.Indent())
            {
                if (Branches.Length > 0)
                {
                    writer.WriteLine("branches:");
                    using (writer.Indent())
                    {
                        Branches.ForEach(WriteValue);
                    }
                }

                if (BranchesIgnore.Length > 0)
                {
                    writer.WriteLine("branches-ignore:");
                    using (writer.Indent())
                    {
                        BranchesIgnore.ForEach(WriteValue);
                    }
                }

                if (Tags.Length > 0)
                {
                    writer.WriteLine("tags:");
                    using (writer.Indent())
                    {
                        Tags.ForEach(WriteValue);
                    }
                }

                if (TagsIgnore.Length > 0)
                {
                    writer.WriteLine("tags-ignore:");
                    using (writer.Indent())
                    {
                        TagsIgnore.ForEach(WriteValue);
                    }
                }

                if (IncludePaths.Length > 0 || ExcludePaths.Length > 0)
                {
                    writer.WriteLine("paths:");
                    using (writer.Indent())
                    {
                        IncludePaths.ForEach(WriteValue);
                        ExcludePaths.Select(x => $"!{x}").ForEach(WriteValue);
                    }
                }
            }
        }
    }
}
