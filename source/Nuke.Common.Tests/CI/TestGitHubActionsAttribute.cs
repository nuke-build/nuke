using System;
using System.IO;
using System.Linq;
using Nuke.Common.CI.GitHubActions;

namespace Nuke.Common.Tests.CI
{
    public class TestGitHubActionsAttribute : GitHubActionsAttribute, ITestConfigurationGenerator
    {
        public TestGitHubActionsAttribute(GitHubActionsImage image, params GitHubActionsImage[] images)
            : base("test", image, images)
        {
        }

        public StreamWriter Stream { get; set; }

        protected override StreamWriter CreateStream()
        {
            return Stream;
        }
    }
}
