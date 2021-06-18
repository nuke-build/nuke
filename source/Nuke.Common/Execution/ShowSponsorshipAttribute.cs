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
                Logger.Normal();

                if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.EqualsOrdinalIgnoreCase("zh"))
                    WriteTranslationRequest();
                else
                    WriteSponsorshipInfo();
            }
        }

        private void WriteTranslationRequest()
        {
            Logger.Info("We want to make NUKE more accessible by providing");
            Logger.Info("our documentation in simplified chinese (zh-CN). 🇨🇳");
            Logger.Info("If you're interested to help, please contact us:");
            Logger.Info("     📧 ithrowexceptions@gmail.com");
            Logger.Normal();
            Logger.Info("Happy building! 🌟");
        }

        private void WriteSponsorshipInfo()
        {
            Logger.Info("If you like NUKE, please support us! 🤓");
            Logger.Info("With a sponsorship you'll gain access to various perks. 🚀");
            Logger.Info("Check out our tiers: https://github.com/sponsors/matkoch");
            Logger.Normal();
            Logger.Info("Happy building! 🌟");
        }
    }
}
