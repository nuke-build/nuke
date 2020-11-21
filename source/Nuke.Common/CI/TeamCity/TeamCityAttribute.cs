// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.CI.TeamCity.Configuration;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Nuke.Common.ValueInjection;
using static Nuke.Common.IO.PathConstruction;

namespace Nuke.Common.CI.TeamCity
{
    [PublicAPI]
    public class TeamCityAttribute : ChainedConfigurationAttributeBase
    {
        public TeamCityAttribute(TeamCityAgentPlatform platform)
        {
            Platform = platform;
        }

        public override HostType HostType => HostType.TeamCity;
        public override string ConfigurationFile => TeamcityDirectory / "settings.kts";
        public override IEnumerable<string> GeneratedFiles => new[] { PomFile, ConfigurationFile };
        private AbsolutePath TeamcityDirectory => NukeBuild.RootDirectory / ".teamcity";
        private string PomFile => TeamcityDirectory / "pom.xml";

        public override IEnumerable<string> RelevantTargetNames => new string[0]
            .Concat(VcsTriggeredTargets)
            .Concat(NightlyTriggeredTargets)
            .Concat(ManuallyTriggeredTargets);

        public string Version { get; set; } = "2018.2";

        public TeamCityAgentPlatform Platform { get; }
        public string Description { get; set; }
        public bool CleanCheckoutDirectory { get; set; } = true;

        public string[] VcsTriggerBranchFilters { get; set; } = new string[0];
        public string[] VcsTriggerRules { get; set; } = { "+:**" };
        public string[] VcsTriggeredTargets { get; set; } = new string[0];

        public bool NightlyBuildAlways { get; set; } = true;
        public string[] NightlyTriggerBranchFilters { get; set; } = new string[0];
        public string[] NightlyTriggerRules { get; set; } = { "+:**" };
        public string[] NightlyTriggeredTargets { get; set; } = new string[0];

        public string[] ManuallyTriggeredTargets { get; set; } = new string[0];

        protected override StreamWriter CreateStream()
        {
            TextTasks.WriteAllLines(
                PomFile,
                ResourceUtility.GetResourceAllLines<TeamCityConfiguration>("pom.xml"));

            return base.CreateStream();
        }

        public override CustomFileWriter CreateWriter(StreamWriter streamWriter)
        {
            return new CustomFileWriter(streamWriter, indentationFactor: 4, commentPrefix: "//");
        }

        public override ConfigurationEntity GetConfiguration(NukeBuild build, IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            return new TeamCityConfiguration
                   {
                       Version = Version,
                       Project = GetProject(build, relevantTargets)
                   };
        }

        public override void SerializeState()
        {
            // serialize difference to start object

            // var stateFile = NukeBuild.TemporaryDirectory / $"{TeamCity.Instance.BuildTypeId}.xml";
            // FileSystemTasks.Touch(stateFile);
            // FileSystemTasks.CopyFile(NukeBuild.TemporaryDirectory / "state.xml", stateFile, FileExistsPolicy.Overwrite);
            // TeamCity.Instance.PublishArtifacts($"+:{stateFile} => .teamcity/states");
        }

        protected virtual TeamCityProject GetProject(NukeBuild build, IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            var vcsRoot = GetVcsRoot(build);
            var lookupTable = new LookupTable<ExecutableTarget, TeamCityBuildType>();
            var buildTypes = relevantTargets
                .SelectMany(x => GetBuildTypes(build, x, vcsRoot, lookupTable, relevantTargets), (x, y) => (ExecutableTarget: x, BuildType: y))
                .ForEachLazy(x => lookupTable.Add(x.ExecutableTarget, x.BuildType))
                .Select(x => x.BuildType).ToArray();

            var parameters = GetGlobalParameters(build, relevantTargets);
            if (Platform == TeamCityAgentPlatform.Windows)
            {
                parameters = parameters
                    .Concat(new TeamCityKeyValueParameter
                            {
                                Key = "teamcity.runner.commandline.stdstreams.encoding",
                                Value = "UTF-8"
                            });
            }

            return new TeamCityProject
                   {
                       VcsRoot = vcsRoot,
                       BuildTypes = buildTypes,
                       Parameters = parameters.ToArray()
                   };
        }

        protected virtual IEnumerable<TeamCityBuildType> GetBuildTypes(
            NukeBuild build,
            ExecutableTarget executableTarget,
            TeamCityVcsRoot vcsRoot,
            LookupTable<ExecutableTarget, TeamCityBuildType> buildTypes,
            IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            var chainLinkTargets = GetInvokedTargets(executableTarget, relevantTargets).ToArray();
            var isPartitioned = ArtifactExtensions.Partitions.ContainsKey(executableTarget.Definition);

            var artifactRules = chainLinkTargets.SelectMany(x =>
                ArtifactExtensions.ArtifactProducts[x.Definition].Select(GetArtifactRule)).ToArray();
            var artifactDependencies = chainLinkTargets.SelectMany(x => (
                from artifactDependency in ArtifactExtensions.ArtifactDependencies[x.Definition]
                let dependency = x.ExecutionDependencies.Single(y => y.Factory == artifactDependency.Item1)
                let rules = (artifactDependency.Item2.Any()
                        ? artifactDependency.Item2
                        : ArtifactExtensions.ArtifactProducts[dependency.Definition])
                    .Select(GetArtifactRule).ToArray()
                select new TeamCityArtifactDependency
                       {
                           BuildType = buildTypes[dependency].Single(y => y.Partition == null),
                           ArtifactRules = rules
                       })).ToArray<TeamCityDependency>();

            var snapshotDependencies = GetTargetDependencies(executableTarget)
                .SelectMany(x => buildTypes[x])
                .Where(x => x.Partition == null)
                .Select(x => new TeamCitySnapshotDependency
                             {
                                 BuildType = x,
                                 FailureAction = TeamCityDependencyFailureAction.FailToStart,
                                 CancelAction = TeamCityDependencyFailureAction.Cancel
                             }).ToArray<TeamCityDependency>();

            if (isPartitioned)
            {
                var (partitionName, totalPartitions) = ArtifactExtensions.Partitions[executableTarget.Definition];
                for (var i = 0; i < totalPartitions; i++)
                {
                    var partition = new Partition { Part = i + 1, Total = totalPartitions };
                    yield return new TeamCityBuildType
                                 {
                                     Id = $"{executableTarget.Name}_P{partition.Part}T{partition.Total}",
                                     Name = $"{executableTarget.Name} {partition}",
                                     Description = executableTarget.Description,
                                     Platform = Platform,
                                     BuildCmdPath = BuildCmdPath,
                                     ArtifactRules = artifactRules,
                                     Partition = partition,
                                     PartitionName = partitionName,
                                     InvokedTargets = chainLinkTargets.Select(x => x.Name).ToArray(),
                                     VcsRoot = new TeamCityBuildTypeVcsRoot { Root = vcsRoot, CleanCheckoutDirectory = CleanCheckoutDirectory },
                                     Dependencies = snapshotDependencies.Concat(artifactDependencies).ToArray()
                                 };
                }

                artifactRules = new[] { "**/*" };
                snapshotDependencies = buildTypes[executableTarget]
                    .Select(x => new TeamCitySnapshotDependency
                                 {
                                     BuildType = x,
                                     FailureAction = TeamCityDependencyFailureAction.FailToStart,
                                     CancelAction = TeamCityDependencyFailureAction.Cancel
                                 }).ToArray<TeamCityDependency>();
                artifactDependencies = buildTypes[executableTarget]
                    .Select(x => new TeamCityArtifactDependency
                                 {
                                     BuildType = x,
                                     ArtifactRules = new[] { "**/*" }
                                 }).ToArray<TeamCityDependency>();
            }

            var parameters = executableTarget.Requirements
                .Where(x => !(x is Expression<Func<bool>>))
                .Select(x => GetParameter(x.GetMemberInfo(), build, required: true)).ToArray();
            var triggers = GetTriggers(executableTarget, buildTypes).ToArray();

            yield return new TeamCityBuildType
                         {
                             Id = executableTarget.Name,
                             Name = executableTarget.Name,
                             Description = executableTarget.Description,
                             Platform = Platform,
                             BuildCmdPath = BuildCmdPath,
                             VcsRoot = new TeamCityBuildTypeVcsRoot
                                       {
                                           Root = vcsRoot,
                                           ShowDependenciesChanges = isPartitioned,
                                           CleanCheckoutDirectory = CleanCheckoutDirectory
                                       },
                             IsComposite = isPartitioned,
                             IsDeployment = ManuallyTriggeredTargets.Contains(executableTarget.Name),
                             InvokedTargets = chainLinkTargets.Select(x => x.Name).ToArray(),
                             ArtifactRules = artifactRules,
                             Dependencies = snapshotDependencies.Concat(artifactDependencies).ToArray(),
                             Parameters = parameters,
                             Triggers = triggers
                         };
        }

        protected virtual IEnumerable<TeamCityTrigger> GetTriggers(
            ExecutableTarget executableTarget,
            LookupTable<ExecutableTarget, TeamCityBuildType> buildTypes)
        {
            if (VcsTriggeredTargets.Contains(executableTarget.Name))
            {
                yield return new TeamCityVcsTrigger
                             {
                                 BranchFilters = VcsTriggerBranchFilters,
                                 TriggerRules = VcsTriggerRules
                             };
            }

            if (NightlyTriggeredTargets.Contains(executableTarget.Name))
            {
                yield return new TeamCityScheduledTrigger
                             {
                                 BranchFilters = NightlyTriggerBranchFilters,
                                 TriggerRules = NightlyTriggerRules,
                                 EnableQueueOptimization = true,
                                 WithPendingChangesOnly = false,
                                 TriggerBuildAlways = NightlyBuildAlways
                             };
            }

            foreach (var triggerDependency in executableTarget.TriggerDependencies)
            {
                yield return new TeamCityFinishBuildTrigger
                             {
                                 BuildType = buildTypes[triggerDependency].Single(x => x.Partition == null)
                             };
            }
        }

        protected virtual TeamCityVcsRoot GetVcsRoot(NukeBuild build)
        {
            return new TeamCityVcsRoot();
        }

        protected virtual IEnumerable<TeamCityParameter> GetGlobalParameters(NukeBuild build, IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            return ValueInjectionUtility.GetParameterMembers(build.GetType(), includeUnlisted: false)
                .Except(relevantTargets.SelectMany(x => x.Requirements
                    .Where(y => !(y is Expression<Func<bool>>))
                    .Select(y => y.GetMemberInfo())))
                .Where(x => x.DeclaringType != typeof(NukeBuild) || x.Name == nameof(NukeBuild.Verbosity))
                .Select(x => GetParameter(x, build, required: false));
        }

        protected virtual TeamCityConfigurationParameter GetParameter(MemberInfo member, NukeBuild build, bool required)
        {
            var attribute = member.GetCustomAttribute<ParameterAttribute>();
            var valueSet = ParameterService.GetParameterValueSet(member, build);

            var defaultValue = member.GetValue(build);
            if (defaultValue != null &&
                (member.GetMemberType() == typeof(AbsolutePath) ||
                 member.GetMemberType() == typeof(Solution) ||
                 member.GetMemberType() == typeof(Project)))
                defaultValue = (UnixRelativePath) GetRelativePath(NukeBuild.RootDirectory, defaultValue.ToString());

            TeamCityParameterType GetParameterType()
            {
                if (member.GetMemberType() == typeof(bool))
                    return TeamCityParameterType.Checkbox;
                if (valueSet != null)
                    return TeamCityParameterType.Select;
                return TeamCityParameterType.Text;
            }

            return new TeamCityConfigurationParameter
                   {
                       Name = member.Name,
                       Description = attribute.Description,
                       Options = valueSet?.ToDictionary(x => x.Item1, x => x.Item2),
                       Type = GetParameterType(),
                       DefaultValue = defaultValue?.ToString(),
                       Display = required ? TeamCityParameterDisplay.Prompt : TeamCityParameterDisplay.Normal,
                       AllowMultiple = member.GetMemberType().IsArray,
                       ValueSeparator = attribute.Separator ?? " "
                   };
        }

        protected virtual string GetArtifactRule(string source)
        {
            if (!NukeBuild.RootDirectory.Contains(source))
                return source;

            var relativeSource = (string) GetUnixRelativePath(NukeBuild.RootDirectory, source);
            var target = relativeSource.TakeWhile(x => x != '*').Reverse().SkipWhile(x => x != '/').Reverse();
            return $"{relativeSource} => {new string(target.ToArray()).TrimEnd('/')}";
        }
    }
}
