// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.SpaceAutomation.Configuration
{
    [PublicAPI]
    public class SpaceAutomationPushTrigger : SpaceAutomationTrigger
    {
        public bool? OnPush { get; set; }
        public string[] OnPushBranchIncludes { get; set; }
        public string[] OnPushBranchExcludes { get; set; }
        public string[] OnPushBranchRegexIncludes { get; set; }
        public string[] OnPushBranchRegexExcludes { get; set; }
        public string[] OnPushPathIncludes { get; set; }
        public string[] OnPushPathExcludes { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            bool HasBranchFilter()
                => OnPushBranchIncludes != null ||
                   OnPushBranchExcludes != null ||
                   OnPushBranchRegexIncludes != null ||
                   OnPushBranchRegexExcludes != null ||
                   OnPushPathIncludes != null ||
                   OnPushPathExcludes != null;

            bool HasPathFilter()
                => OnPushPathIncludes != null ||
                   OnPushPathExcludes != null;

            if (OnPush != null ||
                HasBranchFilter() ||
                HasPathFilter())
            {
                using (writer.WriteBlock("gitPush"))
                {
                    if (OnPush != null)
                        writer.WriteLine($"enabled = {OnPush.ToString().ToLowerInvariant()}");

                    if (HasBranchFilter())
                    {
                        using (writer.WriteBlock("branchFilter"))
                        {
                            new[]
                            {
                                OnPushBranchIncludes?.Select(x => $"+{x.DoubleQuote()}"),
                                OnPushBranchExcludes?.Select(x => $"-{x.DoubleQuote()}"),
                                OnPushBranchRegexIncludes?.Select(x => $"+Regex({x.DoubleQuote()})"),
                                OnPushBranchRegexExcludes?.Select(x => $"-Regex({x.DoubleQuote()})")
                            }.WhereNotNull().SelectMany(x => x).ForEach(x => writer.WriteLine(x));
                        }
                    }

                    if (HasPathFilter())
                    {
                        using (writer.WriteBlock("pathFilter"))
                        {
                            new[]
                            {
                                OnPushPathIncludes?.Select(x => $"+{x.DoubleQuote()}"),
                                OnPushPathExcludes?.Select(x => $"-{x.DoubleQuote()}")
                            }.WhereNotNull().SelectMany(x => x).ForEach(x => writer.WriteLine(x));
                        }
                    }
                }
            }
        }
    }
}
