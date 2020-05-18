// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ApprovalTests;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using Nuke.Common.CI;
using Nuke.Common.CI.AppVeyor;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.CI.TeamCity;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Xunit;

namespace Nuke.Common.Tests.CI
{
    [UseReporter(typeof(DiffReporter))]
    public class ConfigurationGenerationTest
    {
        // TODO: https://github.com/approvals/ApprovalTests.Net/issues/134
        [Theory(Skip = "Line ending")]
        [MemberData(nameof(GetAttributes))]
        public void Test(string testName, ITestConfigurationGenerator attribute)
        {
            var build = new TestBuild();
            var relevantTargets = ExecutableTargetFactory.CreateAll(build, x => x.Compile);

            var stream = new MemoryStream();
            attribute.Stream = new StreamWriter(stream, leaveOpen: true);
            attribute.Generate(build, relevantTargets);

            stream.Seek(offset: 0, SeekOrigin.Begin);
            var reader = new StreamReader(stream);
            var str = reader.ReadToEnd();

            NamerFactory.AdditionalInformation = attribute.GetType().BaseType.NotNull().Name;
            if (testName != null)
                NamerFactory.AdditionalInformation += "." + testName;
            Approvals.Verify(str);
        }

        public static IEnumerable<object[]> GetAttributes()
        {
            return TestBuild.GetAttributes().Select(x => new object[] { x.TestName, x.Generator });
        }

        public class TestBuild : NukeBuild
        {
            public static IEnumerable<(string TestName, IConfigurationGenerator Generator)> GetAttributes()
            {
                yield return
                (
                    null,
                    new TestTeamCityAttribute(TeamCityAgentPlatform.Unix)
                    {
                        Description = "description",
                        Version = "1.3.3.7",
                        NonEntryTargets = new[] { nameof(Clean) },
                        VcsTriggeredTargets = new[] { nameof(Test), nameof(Pack) },
                        ManuallyTriggeredTargets = new[] { nameof(Publish) },
                        NightlyTriggeredTargets = new[] { nameof(Publish) },
                        NightlyTriggerBranchFilters = new[] { "nightly_branch_filter" },
                        VcsTriggerBranchFilters = new[] { "vcs_branch_filter" }
                    }
                );

                yield return
                (
                    null,
                    new TestAzurePipelinesAttribute(
                        AzurePipelinesImage.Ubuntu1804,
                        AzurePipelinesImage.Windows2019)
                    {
                        NonEntryTargets = new[] { nameof(Clean) },
                        InvokedTargets = new[] { nameof(Test) },
                        ExcludedTargets = new[] { nameof(Pack) },
                        TriggerBatch = true,
                        TriggerBranchesInclude = new[] { "included_branch" },
                        TriggerBranchesExclude = new[] { "excluded_branch" },
                        TriggerPathsInclude = new[] { "included_path" },
                        TriggerPathsExclude = new[] { "excluded_path" },
                        TriggerTagsInclude = new[] { "included_tags" },
                        TriggerTagsExclude = new[] { "excluded_tags" }
                    }
                );

                yield return
                (
                    null,
                    new TestAppVeyorAttribute(
                        AppVeyorImage.UbuntuLatest,
                        AppVeyorImage.VisualStudioLatest)
                    {
                        InvokedTargets = new[] { nameof(Test) },
                        BranchesOnly = new[] { "only_branch" },
                        BranchesExcept = new[] { "except_branch" },
                        SkipTags = true,
                        SkipBranchesWithPullRequest = true
                    }
                );

                yield return
                (
                    "simple-triggers",
                    new TestGitHubActionsAttribute(
                        GitHubActionsImage.MacOsLatest,
                        GitHubActionsImage.UbuntuLatest,
                        GitHubActionsImage.WindowsLatest)
                    {
                        On = new[] { GitHubActionsTrigger.Push, GitHubActionsTrigger.PullRequest },
                        InvokedTargets = new[] { nameof(Test) },
                        ImportSecrets = new[] { nameof(ApiKey) },
                        ImportGitHubTokenAs = nameof(GitHubToken),
                    }
                );

                yield return
                (
                    "detailed-triggers",
                    new TestGitHubActionsAttribute(
                        GitHubActionsImage.MacOsLatest,
                        GitHubActionsImage.UbuntuLatest,
                        GitHubActionsImage.WindowsLatest)
                    {
                        InvokedTargets = new[] { nameof(Test) },
                        OnCronSchedule = "* 0 * * *",
                        OnPushBranches = new[] { "push_branch" },
                        OnPushTags = new[] { "push_tag" },
                        OnPushIncludePaths = new[] { "push_include_path" },
                        OnPushExcludePaths = new[] { "push_exclude_path" },
                        OnPullRequestBranches = new[] { "pull_request_branch" },
                        OnPullRequestTags = new[] { "pull_request_tag" },
                        OnPullRequestIncludePaths = new[] { "pull_request_include_path" },
                        OnPullRequestExcludePaths = new[] { "pull_request_exclude_path" },
                    }
                );
            }

            public Target Clean => _ => _
                .Before(Restore);

            [Parameter] public readonly bool IgnoreFailedSources;

            public Target Restore => _ => _;

            [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
            public readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

            public AbsolutePath OutputDirectory => RootDirectory / "output";

            public Target Compile => _ => _
                .DependsOn(Restore);

            public AbsolutePath PackageDirectory => OutputDirectory / "packages";

            public Target Pack => _ => _
                .DependsOn(Compile)
                .Produces(PackageDirectory / "*.nupkg");

            [Partition(2)] public readonly Partition TestPartition;
            public AbsolutePath TestResultDirectory => OutputDirectory / "test-results";

            public Target Test => _ => _
                .DependsOn(Compile)
                .Produces(TestResultDirectory / "*.trx")
                .Produces(TestResultDirectory / "*.xml")
                .Partition(() => TestPartition);

            public string CoverageReportArchive => OutputDirectory / "coverage-report.zip";

            public Target Coverage => _ => _
                .DependsOn(Test)
                .TriggeredBy(Test)
                .Consumes(Test)
                .Produces(CoverageReportArchive);

            [Parameter("NuGet Api Key")] public readonly string ApiKey;

            [Parameter("NuGet Source for Packages")]
            public readonly string Source = "https://api.nuget.org/v3/index.json";

            [Parameter("GitHub Token")] public readonly string GitHubToken;

            public Target Publish => _ => _
                .DependsOn(Clean, Test, Pack)
                .Consumes(Pack)
                .Requires(() => ApiKey);

            public Target Announce => _ => _
                .TriggeredBy(Publish)
                .AssuredAfterFailure();
        }
    }
}
