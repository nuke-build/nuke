// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common.CI.AppVeyor;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.TeamCity;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.Git;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.Tools.OctoVersion
{
    /// <summary>
    /// Injects an instance of <see cref="OctoVersion"/> based on the local repository.
    /// </summary>
    [PublicAPI]
    [UsedImplicitly(ImplicitUseKindFlags.Default)]
    public class OctoVersionAttribute : ValueInjectionAttributeBase
    {
        /// <summary>
        /// Which framework to use when selecting the OctoVersion library from the package
        /// </summary>
        public string Framework { get; set; } = "net5.0";

        /// <summary>
        /// Whether to update the CI build number.
        /// Supports AzurePipelines, TeamCity and AppVeyor.
        /// </summary>
        public bool UpdateBuildNumber { get; set; }

        public override object GetValue(MemberInfo member, object instance)
        {
            var tempOutputFile = NukeBuild.TemporaryDirectory / $"octoversion.{Guid.NewGuid()}.json";
            OctoVersionTasks.OctoVersionExecute(s => s
                .DisableProcessLogOutput()
                .EnableDetectEnvironment()
                .SetOutputJsonFile(tempOutputFile)
                .SetFramework(Framework)
                .When(NukeBuild.IsLocalBuild, s => s
                    .SetCurrentBranch(GitTasks.GitCurrentBranch())));

            var version = GetResult(tempOutputFile);

            if (UpdateBuildNumber)
            {
                AzurePipelines.Instance?.UpdateBuildNumber(version.FullSemVer);
                TeamCity.Instance?.SetBuildNumber(version.FullSemVer);
                AppVeyor.Instance?.UpdateBuildVersion(version.FullSemVer);
            }

            return version;
        }

        private static OctoVersionInfo GetResult(AbsolutePath filename)
        {
            string output = null;
            try
            {
                output = File.ReadAllText(filename);
                var settings = new JsonSerializerSettings { ContractResolver = new AllWritableContractResolver() };
                return JsonConvert.DeserializeObject<OctoVersionInfo>(output, settings);
            }
            catch (Exception exception)
            {
                throw new Exception($"Cannot parse OctoVersion output from filename {filename} as JSON: {output}", exception);
            }
        }
    }
}
