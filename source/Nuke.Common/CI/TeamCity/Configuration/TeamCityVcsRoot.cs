// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.TeamCity.Configuration
{
    public class TeamCityVcsRoot : ConfigurationEntity
    {
        public string Id => "VcsRoot";
        public string Name { get; set; }
        public string Url { get; set; }
        public string Branch { get; set; }
        public int? PollInterval { get; set; }
        public string[] BranchSpec { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            writer.WriteLine($"object {Id} : GitVcsRoot({{");
            using (writer.Indent())
            {
                writer.WriteLine($"name = {Name.DoubleQuote()}");
                writer.WriteLine($"url = {Url.DoubleQuote()}");
                writer.WriteLine($"branch = {Branch.DoubleQuote()}");
                writer.WriteLine($"pollInterval = {PollInterval}");
                if (BranchSpec != null)
                {
                    writer.WriteLine("branchSpec = \"\"\"");
                    using (writer.Indent())
                    {
                        foreach (var branchSpec in BranchSpec)
                            writer.WriteLine(branchSpec);
                    }

                    writer.WriteLine("\"\"\".trimIndent()");
                }
            }

            writer.WriteLine("})");
        }
    }
}
