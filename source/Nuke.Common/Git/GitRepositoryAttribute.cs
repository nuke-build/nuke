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
        public static GitRepository Value { get; private set; }

        public override Type InjectionType => typeof(GitRepository);

        [CanBeNull]
        public override object GetStaticValue ()
        {
            return Value = Value ?? ControlFlow.SuppressErrors(() => GitRepository.TryParse(GetUrl(), GetHead()));
        }

        private static string GetHead ()
        {
            var gitHead = Path.Combine(NukeBuild.Instance.RootDirectory, ".git", "HEAD");
            var headContent = File.ReadAllLines(gitHead);
            return headContent.First();
        }

        private static string GetUrl ()
        {
            var gitConfig = Path.Combine(NukeBuild.Instance.RootDirectory, ".git", "config");
            var configContent = File.ReadAllLines(gitConfig);
            return configContent
                    .Select(x => x.Trim())
                    .SkipWhile(x => x != "[remote \"origin\"]")
                    .Skip(count: 1)
                    .TakeWhile(x => !x.StartsWith("["))
                    .Single(x => x.StartsWithOrdinalIgnoreCase("url = "))
                    .Split('=')[1];
        }
    }
}
