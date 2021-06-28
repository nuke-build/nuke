// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Nuke.Common.CI;
using Nuke.Common.CI.AppVeyor;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using VerifyXunit;
using VerifyTests;
using Xunit;

namespace Nuke.Common.Tests.CI
{
    [UsesVerify]
    public class ConfigurationGenerationTest
    {
        [Theory]
        [MemberData(nameof(GetAttributes))]
        public Task Test(string testName, ITestConfigurationGenerator attribute)
        {
            var build = new TestBuild();
            var relevantTargets = ExecutableTargetFactory.CreateAll(build, x => x.Compile);

            var stream = new MemoryStream();
            attribute.Stream = new StreamWriter(stream, leaveOpen: true);
            attribute.Generate(build, relevantTargets);

            stream.Seek(offset: 0, SeekOrigin.Begin);
            var reader = new StreamReader(stream);
            var str = reader.ReadToEnd();

            return Verifier.Verify(str)
                .UseParameters(testName, attribute.GetType().BaseType.NotNull().Name);
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
                    new TestTeamCityAttribute
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
                        ImportSystemAccessTokenAs = nameof(AzurePipelinesSystemAccessToken),
                        ImportVariableGroups = new[] { "variable-group-1" },
                        ImportSecrets = new[] { nameof(GitHubToken) },
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
                        OnPushTags = new[] { "push_tag/*" },
                        OnPushIncludePaths = new[] { "push_include_path" },
                        OnPushExcludePaths = new[] { "push_exclude_path" },
                        OnPullRequestBranches = new[] { "pull_request_branch" },
                        OnPullRequestTags = new[] { "pull_request_tag" },
                        OnPullRequestIncludePaths = new[] { "pull_request_include_path" },
                        OnPullRequestExcludePaths = new[] { "pull_request_exclude_path/**" },
                        OnWorkflowDispatchOptionalInputs = new[] { "OptionalInput" },
                        OnWorkflowDispatchRequiredInputs = new[] { "RequiredInput" }
                    }
                );

                yield return
                (
                    null,
                    new TestSpaceAutomationAttribute("Name", "mcr.microsoft.com/dotnet/sdk:5.0")
                    {
                        InvokedTargets = new[] { nameof(Test) },
                        VolumeSize = "10.gb",
                        ResourcesCpu = "1.cpu",
                        ResourcesMemory = "2000.mb",
                        OnPush = true,
                        OnPushBranchIncludes = new[] { "refs/heads/include" },
                        OnPushBranchExcludes = new[] { "refs/heads/exclude" },
                        OnPushBranchRegexIncludes = new[] { @"\binclude\b" },
                        OnPushBranchRegexExcludes = new[] { @"\bexclude\b" },
                        OnPushPathIncludes = new[] { "include-path" },
                        OnPushPathExcludes = new[] { "exclude-path" },
                        OnCronSchedule = "* 0 * * *",
                        TimeoutInMinutes = 15
                    }
                );
            }

            public AbsolutePath SourceDirectory => RootDirectory / "src";

            public Target Clean => _ => _
                .Before(Restore);

            [Parameter] public readonly bool IgnoreFailedSources;

            public Target Restore => _ => _
                .Produces(SourceDirectory / "*/obj/**");

            [Parameter("Configuration for compilation")]
            public readonly Configuration Configuration = Configuration.Debug;

            [Parameter] public readonly string[] StringArray = new[] { "first", "second" };
            [Parameter] public readonly int[] IntegerArray = new[] { 1, 2 };
            [Parameter] public readonly Configuration[] ConfigurationArray = new[] { Configuration.Debug, Configuration.Release };

            public AbsolutePath OutputDirectory => RootDirectory / "output";

            public Target Compile => _ => _
                .DependsOn(Restore)
                .Produces(SourceDirectory / "*/bin/**");

            public AbsolutePath PackageDirectory => OutputDirectory / "packages";

            public Target Pack => _ => _
                .DependsOn(Compile)
                .Consumes(Restore, Compile)
                .Produces(PackageDirectory / "*.nupkg");

            public AbsolutePath TestResultDirectory => OutputDirectory / "test-results";

            public Target Test => _ => _
                .DependsOn(Compile)
                .Produces(TestResultDirectory / "*.trx")
                .Produces(TestResultDirectory / "*.xml")
                .Partition(2);

            public string CoverageReportArchive => OutputDirectory / "coverage-report.zip";

            public Target Coverage => _ => _
                .DependsOn(Test)
                .TriggeredBy(Test)
                .Consumes(Test)
                .Produces(CoverageReportArchive);

            [Parameter("NuGet Api Key")] [Secret] public readonly string ApiKey;

            [Parameter("NuGet Source for Packages")]
            public readonly string Source = "https://api.nuget.org/v3/index.json";

            [Parameter("GitHub Token")] public readonly string GitHubToken;

            [Parameter("Azure Pipelines System Access Token")]
            public readonly string AzurePipelinesSystemAccessToken;

            public Target Publish => _ => _
                .DependsOn(Clean, Test, Pack)
                .Consumes(Pack)
                .Requires(() => ApiKey);

            public Target Announce => _ => _
                .TriggeredBy(Publish)
                .AssuredAfterFailure();
        }

        [TypeConverter(typeof(TypeConverter<Configuration>))]
        public class Configuration : Enumeration
        {
            public static Configuration Debug = new Configuration { Value = nameof(Debug) };
            public static Configuration Release = new Configuration { Value = nameof(Release) };

            public static implicit operator string(Configuration configuration)
            {
                return configuration.Value;
            }
        }
    }
}
