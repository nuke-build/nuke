// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;

namespace Nuke.Common.CI.GitHubActions.Configuration
{
    /// <summary>
    /// Github Actions container options <see href="https://docs.github.com/en/actions/learn-github-actions/workflow-syntax-for-github-actions#jobsjob_idcontainer">documentation</see>
    /// </summary>
    [PublicAPI]
    public class GithubActionsContainer : ConfigurationEntity
    {
        public GithubActionsContainer(string image)
        {
            Image = image;
        }

        public string Image { get; }

        public Dictionary<string, string> Env { get; set; } = new();
        public string[] Ports { get; set; } = Array.Empty<string>();
        public string[] Volumes { get; set; } = Array.Empty<string>();
        public string Options { get; set; }
        public GithubActionsContainerCredentials Credentials { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            writer.WriteLine("container:");
            using (writer.Indent())
            {
                writer.WriteLine($"image: {Image}");

                if (Env?.Count != 0)
                {
                    writer.WriteLine("env:");

                    using (writer.Indent())
                    {
                        Env.ForEach(e => writer.WriteLine($"- {e.Key}: {e.Value}"));
                    }
                }

                if (Ports?.Length != 0)
                {
                    writer.WriteLine("ports:");

                    using (writer.Indent())
                    {
                        Ports.ForEach(p => writer.WriteLine($"- {p}"));
                    }
                }

                if (Volumes?.Length != 0)
                {
                    writer.WriteLine("volumes:");

                    using (writer.Indent())
                    {
                        Volumes.ForEach(v => writer.WriteLine($"- {v}"));
                    }
                }

                if (!string.IsNullOrWhiteSpace(Options))
                {
                    writer.WriteLine($"options: {Options}");
                }

                Credentials?.Write(writer);
            }
        }
    }
}
