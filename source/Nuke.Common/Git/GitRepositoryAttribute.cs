// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core;
using Nuke.Core.Injection;
using Nuke.Core.Utilities;

namespace Nuke.Common.Git
{
    /// <inheritdoc/>
    [PublicAPI]
    [UsedImplicitly(ImplicitUseKindFlags.Default)]
    public class GitRepositoryAttribute : StaticInjectionAttributeBase
    {
        private static Lazy<GitRepository> s_value = new Lazy<GitRepository>(() =>
        {
            var gitConfig = Path.Combine(NukeBuild.Instance.RootDirectory, ".git", "config");
            var configContent = File.ReadAllLines(gitConfig);
            var url = configContent
                    .Select(x => x.Trim())
                    .SkipWhile(x => x != "[remote \"origin\"]")
                    .Skip(count: 1)
                    .TakeWhile(x => !x.StartsWith("["))
                    .Single(x => x.StartsWithOrdinalIgnoreCase("url = "))
                    .Split('=')[1];

            return GitRepository.TryParse(url);
        });

        public override Type InjectionType => typeof(GitRepository);

        [CanBeNull]
        public override object GetStaticValue ()
        {
            return s_value.Value;
        }
    }
}
