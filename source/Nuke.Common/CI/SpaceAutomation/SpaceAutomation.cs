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
    public partial class SpaceAutomation : Host, IBuildServer
    {
        public new static SpaceAutomation Instance => Host.Instance as SpaceAutomation;

        internal static bool IsRunningSpaceAutomation => !Environment.GetEnvironmentVariable("JB_SPACE_PROJECT_KEY").IsNullOrEmpty();

        string IBuildServer.Branch => GitBranch;
        string IBuildServer.Commit => GitRevision;

        public string ProjectKey => EnvironmentInfo.GetVariable("JB_SPACE_PROJECT_KEY");
        public string ApiUrl => EnvironmentInfo.GetVariable("JB_SPACE_API_URL");
        public string ClientId => EnvironmentInfo.GetVariable("JB_SPACE_CLIENT_ID");
        public string ClientSecret => EnvironmentInfo.GetVariable("JB_SPACE_CLIENT_SECRET");
        public string ExecutionNumber => EnvironmentInfo.GetVariable("JB_SPACE_EXECUTION_NUMBER");
        public string RepositoryName => EnvironmentInfo.GetVariable("JB_SPACE_GIT_REPOSITORY_NAME");
        public string GitRevision => EnvironmentInfo.GetVariable("JB_SPACE_GIT_REVISION");
        public string GitBranch => EnvironmentInfo.GetVariable("JB_SPACE_GIT_BRANCH");
    }
}
