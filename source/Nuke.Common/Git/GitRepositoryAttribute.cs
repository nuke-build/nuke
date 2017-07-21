// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Core;
using Nuke.Core.Injection;

namespace Nuke.Common.Git
{
    /// <inheritdoc/>
    [PublicAPI]
    public class GitRepositoryAttribute : InjectionAttributeBase
    {
        public override Type InjectionType => typeof(GitRepository);

        [CanBeNull]
        protected override object GetValue (FieldInfo field, NukeBuild buildInstance)
        {
            var gitConfig = Path.Combine(buildInstance.RootDirectory, ".git", "config");
            var configContent = File.ReadAllLines(gitConfig);
            var url = configContent
                    .Select(x => x.Trim())
                    .SkipWhile(x => x != "[remote \"origin\"]")
                    .Skip(count: 1)
                    .TakeWhile(x => !x.StartsWith("["))
                    .Single(x => x.StartsWith("url = ", StringComparison.OrdinalIgnoreCase))
                    .Split('=')[1];

            return GitRepository.TryParse(url);
        }
    }
}
