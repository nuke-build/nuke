// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Nuke.Common.CI;
using Nuke.Common.Git;
using Nuke.Common.Tools.GitHub;
using Nuke.Common.Utilities;

namespace Nuke.Common.Execution
{
    internal class ShowSponsorshipAttribute : BuildExtensionAttributeBase, IOnBuildFinished
    {
        public void OnBuildFinished(NukeBuild build)
        {
            bool HasHighUsage()
                => // interface implementations
                    build.GetType().GetInterfaces().Length > 1 ||
                    // configuration generation
                    build.GetType().GetCustomAttributes<ConfigurationAttributeBase>().Any() ||
                    // global tool
                    NukeBuild.BuildProjectFile == null;

            T TryGetValue<T>(Func<T> func)
            {
                try
                {
                    return func.Invoke();
                }
                catch
                {
                    return default;
                }
            }

            if (build.IsSuccessful &&
                HasHighUsage() &&
                TryGetValue(() => GitRepository.FromLocalDirectory(NukeBuild.RootDirectory)) is { } repository &&
                TryGetValue(() => repository.GetDefaultBranch().GetAwaiter().GetResult()) == null)
            {
                Host.Debug();

                if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.EqualsOrdinalIgnoreCase("zh"))
                    WriteTranslationRequest();
                else
                    WriteSponsorshipInfo();
            }
        }

        private void WriteTranslationRequest()
        {
            Host.Information("We want to make NUKE more accessible by providing");
            Host.Information("our documentation in simplified chinese (zh-CN). 🇨🇳");
            Host.Information("If you're interested to help, please contact us:");
            Host.Information("     📧 ithrowexceptions@gmail.com");
            Host.Information();
            Host.Information("Happy building! 🌟");
        }

        private void WriteSponsorshipInfo()
        {
            Host.Information("If you like NUKE, please support us! 🤓");
            Host.Information("With a sponsorship you'll gain access to various perks. 🚀");
            Host.Information("Check out our tiers: https://github.com/sponsors/matkoch");
            Host.Information();
            Host.Information("Happy building! 🌟");
        }
    }
}
