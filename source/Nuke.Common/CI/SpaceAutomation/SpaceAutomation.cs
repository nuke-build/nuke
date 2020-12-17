// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.SpaceAutomation
{
    /// <summary>
    /// Interface according to the <a href="https://www.jetbrains.com/help/space/automation.html">official website</a>.
    /// </summary>
    [PublicAPI]
    [CI]
    [ExcludeFromCodeCoverage]
    public class SpaceAutomation
    {
        private static Lazy<SpaceAutomation> s_instance = new Lazy<SpaceAutomation>(() => new SpaceAutomation());

        public static SpaceAutomation Instance => NukeBuild.Host == HostType.SpaceAutomation ? s_instance.Value : null;

        internal static bool IsRunningSpaceAutomation => !Environment.GetEnvironmentVariable("JB_SPACE_PROJECT_KEY").IsNullOrEmpty();

        public string ProjectKey => EnvironmentInfo.GetVariable<string>("JB_SPACE_PROJECT_KEY");
        public string ApiUrl => EnvironmentInfo.GetVariable<string>("JB_SPACE_API_URL");
        public string ClientId => EnvironmentInfo.GetVariable<string>("JB_SPACE_CLIENT_ID");
        public string ClientSecret => EnvironmentInfo.GetVariable<string>("JB_SPACE_CLIENT_SECRET");
        public string ExecutionNumber => EnvironmentInfo.GetVariable<string>("JB_SPACE_EXECUTION_NUMBER");
        public string RepositoryName => EnvironmentInfo.GetVariable<string>("JB_SPACE_GIT_REPOSITORY_NAME");
        public string GitRevision => EnvironmentInfo.GetVariable<string>("JB_SPACE_GIT_REVISION");
        public string GitBranch => EnvironmentInfo.GetVariable<string>("JB_SPACE_GIT_BRANCH");
    }
}
