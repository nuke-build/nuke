// // Copyright 2019 Maintainers of NUKE.
// // Distributed under the MIT License.
// // https://github.com/nuke-build/nuke/blob/master/LICENSE
//
// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Linq;
// using System.Linq.Expressions;
// using System.Reflection;
// using JetBrains.Annotations;
// using Nuke.Common.BuildServers.Configuration;
// using Nuke.Common.Execution;
// using Nuke.Common.Git;
// using Nuke.Common.IO;
// using Nuke.Common.ProjectModel;
// using Nuke.Common.Tooling;
// using Nuke.Common.Utilities;
// using Nuke.Common.Utilities.Collections;
// using static Nuke.Common.IO.PathConstruction;
// using static Nuke.Common.Utilities.ResourceUtility;
// using static Nuke.Common.Utilities.TemplateUtility;
//
// namespace Nuke.Common.BuildServers
// {
//     [PublicAPI]
//     public class TeamCityConfigurationGenerator : Attribute, IPreLogoBuildExtension, IBuildFinishedExtension
//     {
//         public TeamCityConfigurationGenerator(TeamCityAgentPlatform platform)
//         {
//             Platform = platform;
//         }
//
//         public TeamCityAgentPlatform Platform { get; }
//         public string Description { get; set; }
//         public string DefaultBranch { get; set; } = "develop";
//
//         public string VcsTriggerBranchFilter { get; set; } = "";
//         public string VcsTriggerRules { get; set; } = "+:**";
//         public string[] VcsTriggeredTargets { get; set; } = new string[0];
//
//         public string NightlyTriggerBranchFilter { get; set; } = "";
//         public string NightlyTriggerRules { get; set; } = "+:**";
//         public string[] NightlyTriggeredTargets { get; set; } = new string[0];
//
//         public string[] ManuallyTriggeredTargets { get; set; } = new string[0];
//         public string[] NonEntryTargets { get; set; } = new string[0];
//         public string[] ExcludedTargets { get; set; } = new string[0];
//
//         public void Execute(
//             NukeBuild build,
//             IReadOnlyCollection<ExecutableTarget> executableTargets,
//             IReadOnlyCollection<ExecutableTarget> executionPlan)
//         {
//             if (!ParameterService.Instance.GetParameter<bool>(Constants.TeamCityConfigurationParameterName))
//                 return;
//
//             var buildTypeTargets = VcsTriggeredTargets.Concat(ManuallyTriggeredTargets)
//                 .SelectMany(x => ExecutionPlanner.GetExecutionPlan(executableTargets, new[] { x }))
//                 .Distinct()
//                 .Where(x => !ExcludedTargets.Contains(x.Name) && !NonEntryTargets.Contains(x.Name)).ToList();
//             var configuration = GetConfiguration(build, buildTypeTargets).ToList();
//
//             ControlFlow.Assert(NukeBuild.RootDirectory != null, "NukeBuild.RootDirectory != null");
//             var teamcityDirectory = NukeBuild.RootDirectory / ".teamcity";
//
//             var configurationFile = teamcityDirectory / "settings.kts";
//             var configurationUserCode = File.Exists(configurationFile)
//                 ? ExtractAndRemoveRegions(TextTasks.ReadAllLines(configurationFile).ToList(), "// BEGIN USER", "// END USER")
//                 : new LookupTable<string, string>();
//             AddRegion(configuration, "// BEGIN USER MODIFICATIONS", configurationUserCode["MODIFICATIONS"]);
//             AddRegion(configuration, "// BEGIN USER FUNCTIONS", configurationUserCode["FUNCTIONS"]);
//
//             TextTasks.WriteAllLines(configurationFile, configuration);
//             TextTasks.WriteAllLines(teamcityDirectory / "pom.xml", GetResourceAllLines<TeamCityConfigurationGenerator>("teamcity.pom.xml"));
//
//             Environment.Exit(0);
//         }
//
//         private IEnumerable<string> GetConfiguration(NukeBuild build, IReadOnlyCollection<ExecutableTarget> buildTypeTargets)
//         {
//             var configuration = new List<string>();
//
//             configuration.AddRange(new[]
//                                    {
//                                        "// THIS FILE IS AUTO-GENERATED",
//                                        "// ITS CONTENT IS OVERWRITTEN WITH EXCEPTION OF MARKED USER BLOCKS",
//                                        ""
//                                    });
//             configuration.AddRange(GetImports());
//             configuration.AddRange(GetProject(build, buildTypeTargets));
//             configuration.AddRange(GetVcsRoot());
//             foreach (var target in buildTypeTargets)
//                 configuration.AddRange(GetBuildTypes(build, target));
//
//             return configuration;
//         }
//
//         protected virtual IEnumerable<string> GetImports()
//         {
//             yield return "import jetbrains.buildServer.configs.kotlin.v2018_1.*";
//             yield return "import jetbrains.buildServer.configs.kotlin.v2018_1.buildFeatures.*";
//             yield return "import jetbrains.buildServer.configs.kotlin.v2018_1.buildSteps.*";
//             yield return "import jetbrains.buildServer.configs.kotlin.v2018_1.triggers.*";
//             yield return "import jetbrains.buildServer.configs.kotlin.v2018_1.vcs.*";
//             yield return "";
//         }
//
//         protected virtual IEnumerable<string> GetProject(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets)
//         {
//             yield return "version = \"2019.1\"";
//             yield return "";
//             yield return "// BEGIN USER FUNCTIONS";
//             yield return "// END USER FUNCTIONS";
//             yield return "";
//             yield return "project {";
//
//             if (Description != null)
//             {
//                 yield return $"    description = {Description.DoubleQuote()}";
//                 yield return "";
//             }
//
//             yield return $"    vcsRoot({GetVcsRootName()})";
//             yield return "";
//             foreach (var executableTarget in executableTargets)
//             {
//                 var buildTypeNames = GetBuildTypeNames(executableTarget).ToList();
//                 foreach (var buildTypeName in buildTypeNames)
//                     yield return $"    buildType({buildTypeName})";
//             }
//
//             yield return "";
//             yield return $"    buildTypesOrder = arrayListOf({executableTargets.SelectMany(GetBuildTypeNames).JoinComma()})";
//             yield return "";
//             yield return "    // BEGIN USER MODIFICATIONS";
//             yield return "    // END USER MODIFICATIONS";
//
//             var parameters = GetGlobalParameters(build).ToList();
//             if (parameters.Any())
//             {
//                 yield return "";
//                 yield return $"    params {{";
//                 foreach (var parameter in parameters)
//                     yield return $"        {parameter}";
//                 yield return $"    }}";
//             }
//
//             yield return "}";
//         }
//
//         protected virtual IEnumerable<string> GetBuildTypes(NukeBuild build, ExecutableTarget target)
//         {
//             var buildTypeNames = GetBuildTypeNames(target).ToList();
//             var partitions = GetPartitions(target);
//             for (var partition = 0; partition <= partitions; partition++)
//             {
//                 var isPartition = partitions > 0 && partition < partitions;
//                 var isComposite = partitions > 0 && partition == partitions;
//                 var partitionString = isPartition ? $"{partition + 1}/{partitions}" : null;
//
//                 yield return $"object {buildTypeNames[partition]} : BuildType({{";
//                 yield return $"    name = {(target.Name + (isPartition ? $" {partitionString}" : string.Empty)).DoubleQuote()}";
//
//                 if (target.Description != null)
//                     yield return $"    description = {target.Description.DoubleQuote()}";
//
//                 if (isComposite)
//                     yield return "    type = Type.COMPOSITE";
//
//                 yield return $"    vcs {{";
//                 yield return $"        root({GetVcsRootName()})";
//                 if (isComposite)
//                     yield return $"        showDependenciesChanges = true";
//                 yield return $"    }}";
//
//                 var artifactRules = ArtifactExtensions.ArtifactProducts[target.Definition].Select(GetArtifactRule).ToList();
//                 if (artifactRules.Any())
//                 {
//                     yield return $"    artifactRules = \"\"\"";
//                     foreach (var artifactRule in artifactRules)
//                         yield return $"        +:{artifactRule}";
//                     yield return $"    \"\"\".trimIndent()";
//                 }
//
//                 if (!isComposite)
//                 {
//                     var steps = GetSteps(target, partitionString).ToList();
//                     if (steps.Any())
//                     {
//                         yield return $"    steps {{";
//                         foreach (var step in steps)
//                             yield return $"        {step}";
//                         yield return $"    }}";
//                     }
//                 }
//
//                 var parameters = GetParameters(build, target).ToList();
//                 if (parameters.Any())
//                 {
//                     yield return $"    params {{";
//                     foreach (var parameter in parameters)
//                         yield return $"        {parameter}";
//                     yield return $"    }}";
//                 }
//
//                 if (!isPartition)
//                 {
//                     var triggers = GetVcsTrigger(target)
//                         .Concat(GetNightlyTrigger(target))
//                         .Concat(GetFinishBuildTrigger(target)).ToList();
//
//                     if (triggers.Any())
//                     {
//                         yield return $"    triggers {{";
//                         foreach (var trigger in triggers)
//                             yield return $"        {trigger}";
//                         yield return $"    }}";
//                     }
//                 }
//
//                 var dependencies = !isComposite
//                     ? GetSnapshotDependencies(target).Concat(GetArtifactDependencies(target)).ToList()
//                     : GetCompositeSnapshotDependencies(target).ToList();
//                 if (dependencies.Any())
//                 {
//                     yield return $"    dependencies {{";
//                     foreach (var dependency in dependencies)
//                         yield return $"        {dependency}";
//                     yield return $"    }}";
//                 }
//
//                 yield return $"}})";
//             }
//         }
//
//         protected virtual IEnumerable<string> GetSteps(ExecutableTarget target, string partition = null)
//         {
//             var invokedTargets = target
//                 .DescendantsAndSelf(x => x.ExecutionDependencies, x => NonEntryTargets.Contains(x.Name))
//                 .Where(x => x == target || NonEntryTargets.Contains(x.Name))
//                 .Reverse()
//                 .Select(x => x.Name)
//                 .JoinSpace();
//
//             var arguments = $"{invokedTargets} --skip";
//             if (partition != null)
//                 arguments += $" --partition-{target.Name.ToLower()} {partition}";
//
//             if (Platform == TeamCityAgentPlatform.Windows)
//             {
//                 yield return $"powerShell {{";
//                 yield return $"    scriptMode = file {{ path = \"build.ps1\" }}";
//                 yield return $"    param(\"jetbrains_powershell_scriptArguments\", \"{arguments}\")";
//                 yield return $"    noProfile = true";
//                 yield return $"}}";
//             }
//             else
//             {
//                 yield return $"exec {{";
//                 yield return $"    path = \"build.sh\"";
//                 yield return $"    arguments = \"{arguments}\"";
//                 yield return $"}}";
//             }
//         }
//
//         protected virtual IEnumerable<string> GetGlobalParameters(NukeBuild build)
//         {
//             var declarations = new List<string>();
//
//             if (Platform == TeamCityAgentPlatform.Windows)
//                 declarations.Add("param(\"teamcity.runner.commandline.stdstreams.encoding\", \"IBM-437\")");
//
//             var parameters = InjectionUtility.GetParameterMembers(build.GetType(), includeUnlisted: false)
//                 .Except(build.ExecutableTargets.SelectMany(x => x.Requirements
//                     .Where(y => !(y is Expression<Func<bool>>))
//                     .Select(y => y.GetMemberInfo())))
//                 .Where(x => x.DeclaringType != typeof(NukeBuild) || x.Name == nameof(NukeBuild.Verbosity));
//             declarations.AddRange(parameters.SelectMany(x => GetParameter(x, build, prompt: false)));
//
//             return declarations;
//         }
//
//         protected virtual IEnumerable<string> GetParameters(NukeBuild build, ExecutableTarget target)
//         {
//             var parameters = target.Requirements
//                 .Where(x => !(x is Expression<Func<bool>>))
//                 .Select(x => x.GetMemberInfo());
//
//             return parameters.SelectMany(x => GetParameter(x, build, prompt: true));
//         }
//
//         private static IEnumerable<string> GetParameter(MemberInfo parameter, NukeBuild build, bool prompt)
//         {
//             var attribute = parameter.GetCustomAttribute<ParameterAttribute>();
//             var name = parameter.Name;
//             var description = attribute.Description;
//             var display = $"ParameterDisplay.{(prompt ? "PROMPT" : "NORMAL")}";
//             var valueSet = ParameterService.Instance.GetParameterValueSet(parameter, build);
//             var type = valueSet != null
//                 ? "select"
//                 : "text";
//             var defaultValue = parameter.GetValue(build);
//             if (parameter.GetMemberType() == typeof(AbsolutePath) ||
//                 parameter.GetMemberType() == typeof(Solution) ||
//                 parameter.GetMemberType() == typeof(Project))
//                 defaultValue = (UnixRelativePath) GetRelativePath(NukeBuild.RootDirectory, defaultValue.ToString());
//
//             yield return $"{type}({("env." + name).DoubleQuote()},";
//             yield return $"    label = {name.DoubleQuote()},";
//
//             if (description != null)
//                 yield return $"    description = {description.DoubleQuote()},";
//
//             if (parameter.GetMemberType().IsArray)
//             {
//                 yield return $"    allowMultiple = true,";
//                 yield return $"    valueSeparator = \"{attribute.Separator ?? " "}\",";
//             }
//
//             if (valueSet != null)
//             {
//                 var mappings = valueSet.Select(x => $"{x.Item1.DoubleQuote()} to {x.Item2.ToString().DoubleQuote()}");
//                 yield return $"    options = listOf({mappings.JoinComma()}),";
//             }
//
//             if (!prompt && valueSet == null)
//                 yield return $"    allowEmpty = true,";
//
//             yield return $"    value = \"{defaultValue}\",";
//             yield return $"    display = {display})";
//         }
//
//         protected virtual IEnumerable<string> GetVcsTrigger(ExecutableTarget target)
//         {
//             if (VcsTriggeredTargets.Contains(target.Name))
//             {
//                 yield return $"vcs {{";
//                 yield return $"    branchFilter = {VcsTriggerBranchFilter.DoubleQuote()}";
//                 yield return $"    triggerRules = {VcsTriggerRules.DoubleQuote()}";
//                 yield return $"}}";
//             }
//         }
//
//         protected virtual IEnumerable<string> GetNightlyTrigger(ExecutableTarget target)
//         {
//             if (NightlyTriggeredTargets.Contains(target.Name))
//             {
//                 yield return $"schedule {{";
//                 yield return $"    schedulingPolicy = daily {{";
//                 yield return $"        hour = 3";
//                 yield return $"        timezone = \"Europe/Berlin\"";
//                 yield return $"    }}";
//                 yield return $"    branchFilter = {NightlyTriggerBranchFilter.DoubleQuote()}";
//                 yield return $"    triggerRules = {NightlyTriggerRules.DoubleQuote()}";
//                 yield return $"    triggerBuild = always()";
//                 yield return $"    withPendingChangesOnly = false";
//                 yield return $"    enableQueueOptimization = false";
//                 yield return $"    param(\"cronExpression_min\",\"3\")";
//                 yield return $"}}";
//             }
//         }
//
//         protected virtual IEnumerable<string> GetFinishBuildTrigger(ExecutableTarget target)
//         {
//             foreach (var triggerDependency in target.TriggerDependencies)
//             {
//                 yield return $"finishBuildTrigger {{";
//                 yield return $"    buildType = {triggerDependency.Name.DoubleQuote()}";
//                 yield return $"}}";
//             }
//         }
//
//         protected virtual IEnumerable<string> GetSnapshotDependencies(ExecutableTarget target)
//         {
//             var dependentBuildTypeNames = target.ExecutionDependencies
//                 .Where(x => !ExcludedTargets.Contains(x.Name) && !NonEntryTargets.Contains(x.Name))
//                 .Select(x => x.Name);
//             foreach (var dependency in dependentBuildTypeNames)
//             {
//                 yield return $"snapshot({dependency}) {{";
//                 yield return $"}}";
//             }
//         }
//
//         protected virtual IEnumerable<string> GetCompositeSnapshotDependencies(ExecutableTarget target)
//         {
//             foreach (var dependency in GetBuildTypeNames(target).Reverse().Skip(1).Reverse())
//             {
//                 yield return $"snapshot({dependency}) {{";
//                 yield return "    onDependencyFailure = FailureAction.FAIL_TO_START";
//                 yield return $"}}";
//             }
//         }
//
//         private string GetArtifactRule(string rule)
//         {
//             if (IsDescendantPath(NukeBuild.RootDirectory, rule))
//                 rule = GetRelativePath(NukeBuild.RootDirectory, rule);
//
//             return HasPathRoot(rule)
//                 ? rule
//                 : (UnixRelativePath) rule;
//         }
//
//         protected virtual IEnumerable<string> GetArtifactDependencies(ExecutableTarget target)
//         {
//             foreach (var artifactDependency in ArtifactExtensions.ArtifactDependencies[target.Definition])
//             {
//                 var dependency = target.ExecutionDependencies.Single(x => x.Factory == artifactDependency.Item1);
//                 var artifactRules = (artifactDependency.Item2.Any()
//                         ? artifactDependency.Item2
//                         : ArtifactExtensions.ArtifactProducts[dependency.Definition])
//                     .Select(GetArtifactRule).ToList();
//
//                 foreach (var buildTypeName in GetBuildTypeNames(dependency))
//                 {
//                     yield return $"artifacts({buildTypeName}) {{";
//                     yield return $"    artifactRules = \"\"\"";
//                     foreach (var artifactRule in artifactRules)
//                         yield return $"        +:{artifactRule}";
//                     yield return $"    \"\"\".trimIndent()";
//                     yield return $"}}";
//                 }
//             }
//         }
//
//         protected virtual IEnumerable<string> GetVcsRoot()
//         {
//             var repository = GitRepository.FromLocalDirectory(NukeBuild.RootDirectory);
//             var httpsUrl = repository.HttpsUrl;
//
//             yield return $"object {GetVcsRootName()} : GitVcsRoot({{";
//             yield return $"    name = {$"{httpsUrl}#refs/heads/{DefaultBranch}".DoubleQuote()}";
//             yield return $"    url = {httpsUrl.DoubleQuote()}";
//             yield return $"    branch = {$"refs/heads/{DefaultBranch}".DoubleQuote()}";
//             yield return $"    pollInterval = 60";
//             yield return $"    branchSpec = {"+:refs/heads/*".DoubleQuote()}";
//             yield return $"}})";
//         }
//
//         protected virtual string GetVcsRootName()
//         {
//             // return "DslContext.settingsRoot";
//             return $"VcsRoot";
//         }
//
//         protected virtual IEnumerable<string> GetBuildTypeNames(ExecutableTarget target)
//         {
//             var partitions = GetPartitions(target);
//             return partitions == 1
//                 ? new[] { target.Name }
//                 : Enumerable.Range(0, partitions).Select(x => $"{target.Name}_P{x + 1}").Concat(target.Name);
//         }
//
//         private int GetPartitions(ExecutableTarget target)
//         {
//             return ArtifactExtensions.Partitions.TryGetValue(target.Definition, out var partitions)
//                 ? partitions
//                 : 0;
//         }
//
//         public void OnBuildFinished(NukeBuild build)
//         {
//             if (TeamCity.Instance == null)
//                 return;
//
//             var stateFile = NukeBuild.TemporaryDirectory / $"{TeamCity.Instance.BuildTypeId}.xml";
//             FileSystemTasks.Touch(stateFile);
//             // FileSystemTasks.CopyFile(NukeBuild.TemporaryDirectory / "state.xml", stateFile, FileExistsPolicy.Overwrite);
//             TeamCity.Instance.PublishArtifacts($"+:{stateFile} => .teamcity/states");
//         }
//     }
// }


