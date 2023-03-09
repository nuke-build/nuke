// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections;
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
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Nuke.Common.ValueInjection;
using static Nuke.Common.IO.PathConstruction;

namespace Nuke.Common.CI.TeamCity
{
    [PublicAPI]
    public class TeamCityAttribute : ChainedConfigurationAttributeBase
    {
        public override Type HostType => typeof(TeamCity);
        public override AbsolutePath ConfigurationFile => TeamcityDirectory / "settings.kts";
        public override IEnumerable<AbsolutePath> GeneratedFiles => new[] { PomFile, ConfigurationFile };
        private AbsolutePath TeamcityDirectory => Build.RootDirectory / ".teamcity";
        private AbsolutePath PomFile => TeamcityDirectory / "pom.xml";

        public override IEnumerable<string> RelevantTargetNames => new string[0]
            .Concat(VcsTriggeredTargets)
            .Concat(NightlyTriggeredTargets)
            .Concat(ManuallyTriggeredTargets);

        public string Version { get; set; } = "2021.2";

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

        public string[] ImportSecrets { get; set; } = new string[0];

        protected override StreamWriter CreateStream()
        {
            PomFile.WriteAllLines(ResourceUtility.GetResourceAllLines<TeamCityConfiguration>("pom.xml"));

            return base.CreateStream();
        }

        public override CustomFileWriter CreateWriter(StreamWriter streamWriter)
        {
            return new CustomFileWriter(streamWriter, indentationFactor: 4, commentPrefix: "//");
        }

        public override ConfigurationEntity GetConfiguration(IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            return new TeamCityConfiguration
                   {
                       Version = Version,
                       Project = GetProject(relevantTargets)
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

        protected virtual TeamCityProject GetProject(IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            var vcsRoot = GetVcsRoot();
            var lookupTable = new LookupTable<ExecutableTarget, TeamCityBuildType>();
            var buildTypes = relevantTargets
                .SelectMany(x => GetBuildTypes(x, vcsRoot, lookupTable, relevantTargets), (x, y) => (ExecutableTarget: x, BuildType: y))
                .ForEachLazy(x => lookupTable.Add(x.ExecutableTarget, x.BuildType))
                .Select(x => x.BuildType).ToArray();

            var parameters = GetGlobalParameters(relevantTargets);

            return new TeamCityProject
                   {
                       VcsRoot = vcsRoot,
                       BuildTypes = buildTypes,
                       Parameters = parameters.ToArray()
                   };
        }

        protected virtual IEnumerable<TeamCityBuildType> GetBuildTypes(
            ExecutableTarget executableTarget,
            TeamCityVcsRoot vcsRoot,
            LookupTable<ExecutableTarget, TeamCityBuildType> buildTypes,
            IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            var chainLinkTargets = GetInvokedTargets(executableTarget, relevantTargets).ToArray();
            var isPartitioned = executableTarget.PartitionSize != null;

            var artifactRules = chainLinkTargets.SelectMany(x => x.ArtifactProducts.Select(GetArtifactRule)).ToArray();
            var artifactDependencies = chainLinkTargets.SelectMany(x =>
                from dependency in x.ArtifactDependencies
                let rules = dependency.Select(GetArtifactRule).ToArray()
                select new TeamCityArtifactDependency
                       {
                           BuildType = buildTypes[dependency.Key].Single(y => y.Partition == null),
                           ArtifactRules = rules
                       }).ToArray<TeamCityDependency>();

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
                var totalPartitions = executableTarget.PartitionSize.Value;
                for (var i = 0; i < totalPartitions; i++)
                {
                    var partition = new Partition { Part = i + 1, Total = totalPartitions };
                    yield return new TeamCityBuildType
                                 {
                                     Id = $"{executableTarget.Name}_P{partition.Part}T{partition.Total}",
                                     Name = $"{executableTarget.Name} {partition}",
                                     Description = executableTarget.Description,
                                     BuildCmdPath = BuildCmdPath,
                                     ArtifactRules = artifactRules,
                                     Partition = partition,
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
                                     FailureAction = TeamCityDependencyFailureAction.AddProblem,
                                     CancelAction = TeamCityDependencyFailureAction.Cancel
                                 }).ToArray<TeamCityDependency>();
                artifactDependencies = buildTypes[executableTarget]
                    .Select(x => new TeamCityArtifactDependency
                                 {
                                     BuildType = x,
                                     ArtifactRules = new[] { "**/*" }
                                 }).ToArray<TeamCityDependency>();
            }

            var parameters = executableTarget.DelegateRequirements
                .Where(x => x is not Expression<Func<bool>>)
                .Select(x => GetParameter(x.GetMemberInfo(), required: true))
                .Concat(new TeamCityKeyValueParameter(
                    "teamcity.ui.runButton.caption",
                    executableTarget.Name.SplitCamelHumpsWithKnownWords().JoinSpace())).ToArray();
            var triggers = GetTriggers(executableTarget, buildTypes).ToArray();

            yield return new TeamCityBuildType
                         {
                             Id = executableTarget.Name,
                             Name = executableTarget.Name,
                             Description = executableTarget.Description,
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

        protected virtual TeamCityVcsRoot GetVcsRoot()
        {
            return new TeamCityVcsRoot();
        }

        protected virtual IEnumerable<TeamCityParameter> GetGlobalParameters(IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            return ValueInjectionUtility.GetParameterMembers(Build.GetType(), includeUnlisted: false)
                // TODO: except build.ExecutableTargets ?
                .Except(relevantTargets.SelectMany(x => x.DelegateRequirements
                    .Where(y => y is not Expression<Func<bool>>)
                    .Select(y => y.GetMemberInfo())))
                .Where(x => !x.HasCustomAttribute<SecretAttribute>())
                .Where(x => x.DeclaringType != typeof(NukeBuild) || x.Name == nameof(NukeBuild.Verbosity))
                .Select(x => GetParameter(x, required: false))
                .Concat(GetSecretParameters())
                .Concat(GetDefaultParameters());
        }

        protected virtual IEnumerable<TeamCityParameter> GetSecretParameters()
        {
            var guids = Build.GetType().GetCustomAttributes<TeamCityTokenAttribute>()
                .ToDictionary(x => x.Name, x => $"credentialsJSON:{Guid.Parse(x.Guid):D}");
            return ImportSecrets.Select(x =>
                new TeamCityConfigurationParameter
                {
                    Type = TeamCityParameterType.Password,
                    Name = x,
                    DefaultValue = guids.GetValueOrDefault(x),
                    Display = TeamCityParameterDisplay.Hidden
                });
        }

        protected virtual IEnumerable<TeamCityParameter> GetDefaultParameters()
        {
            yield return new TeamCityKeyValueParameter("teamcity.runner.commandline.stdstreams.encoding", "UTF-8");
            yield return new TeamCityKeyValueParameter("teamcity.git.fetchAllHeads", "true");
        }

        protected virtual TeamCityParameter GetParameter(MemberInfo member, bool required)
        {
            var attribute = member.GetCustomAttribute<ParameterAttribute>();
            var valueSet = ParameterService.GetParameterValueSet(member, Build);
            var valueSeparator = attribute.Separator ?? " ";

            // TODO: Abstract AbsolutePath/Solution/Project etc.
            var defaultValue = !member.HasCustomAttribute<SecretAttribute>() ? member.GetValue(Build) : default(string);
            // TODO: enumerables of ...
            if (defaultValue != null &&
                (member.GetMemberType() == typeof(AbsolutePath) ||
                 member.GetMemberType() == typeof(Solution) ||
                 member.GetMemberType() == typeof(Project)))
                defaultValue = (UnixRelativePath) GetRelativePath(Build.RootDirectory, defaultValue.ToString());

            TeamCityParameterType GetParameterType()
            {
                if (member.HasCustomAttribute<SecretAttribute>())
                    return TeamCityParameterType.Password;
                if (member.GetMemberType() == typeof(bool))
                    return TeamCityParameterType.Checkbox;
                if (valueSet != null)
                    return TeamCityParameterType.Select;
                return TeamCityParameterType.Text;
            }

            return new TeamCityConfigurationParameter
                   {
                       // TODO: #555 - Should this use ParameterService.GetParameterMemberName(member) ?
                       Name = ParameterService.GetParameterMemberName(member),
                       Description = attribute.Description,
                       Options = valueSet?.ToDictionary(x => x.Item1, x => x.Item2),
                       Type = GetParameterType(),
                       DefaultValue = member.GetMemberType().IsArray && defaultValue is IEnumerable enumerable
                           ? enumerable.Cast<object>().Select(x => x.ToString()).Join(valueSeparator)
                           : defaultValue?.ToString(),
                       Display = required ? TeamCityParameterDisplay.Prompt : TeamCityParameterDisplay.Normal,
                       AllowMultiple = member.GetMemberType().IsArray && valueSet is not null,
                       ValueSeparator = valueSeparator
                   };
        }

        protected virtual string GetArtifactRule(string source)
        {
            if (!Build.RootDirectory.Contains(source))
                return source;

            var relativeSource = (string) GetUnixRelativePath(Build.RootDirectory, source);
            var target = relativeSource.TakeWhile(x => x != '*').Reverse().SkipWhile(x => x != '/').Reverse();
            return $"{relativeSource} => {new string(target.ToArray()).TrimEnd('/')}";
        }
    }
}
