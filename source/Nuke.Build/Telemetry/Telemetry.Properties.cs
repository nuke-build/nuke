// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Nuke.Common.CI;
using Nuke.Common.Git;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.Execution
{
    internal partial class Telemetry
    {
        private static readonly string[] s_knownTargets = { "Restore", "Compile", "Test" };

        private static IDictionary<string, string> GetCommonProperties(INukeBuild build = null)
        {
            var version = ControlFlow.SuppressErrors(
                () =>
                {
                    var dotnet = ToolResolver.GetEnvironmentOrPathTool("dotnet");
                    return dotnet.Invoke($"--version", logInvocation: false, logOutput: false).StdToText();
                },
                logWarning: false);

            return new Dictionary<string, string>
                   {
                       ["os_platform"] = EnvironmentInfo.Platform.ToString(),
                       ["os_architecture"] = RuntimeInformation.OSArchitecture.ToString(),
                       ["version_dotnet_sdk"] = version,
                       ["version_nuke_common"] = build != null ? typeof(NukeBuild).Assembly.GetVersionText() : null,
                       ["version_nuke_global_tool"] = build != null
                           ? EnvironmentInfo.Variables.GetValueOrDefault(Constants.GlobalToolVersionEnvironmentKey)
                           : Assembly.GetEntryAssembly().GetVersionText()
                   };
        }

        private static IDictionary<string, string> GetRepositoryProperties(string directory)
        {
            var repository = ControlFlow.SuppressErrors(() => GitRepository.FromLocalDirectory(directory), logWarning: false);
            if (repository == null)
                return new Dictionary<string, string>();

            var providers =
                new List<(Func<bool>, string)>
                {
                    (() => repository.Endpoint?.ContainsOrdinalIgnoreCase("github.com") ?? false, "GitHub"),
                    (() => repository.Endpoint?.ContainsOrdinalIgnoreCase("gitlab.com") ?? false, "GitLab"),
                    (() => repository.Endpoint?.ContainsOrdinalIgnoreCase("bitbucket.org") ?? false, "Bitbucket"),
                    (() => repository.Endpoint?.ContainsOrdinalIgnoreCase("jetbrains.space") ?? false, "JetBrains"),
                    (() => repository.Endpoint?.ContainsOrdinalIgnoreCase("visualstudio.com") ?? false, "Azure")
                };

            var branches =
                new List<(Func<bool>, string)>
                {
                    (() => repository.IsOnMainOrMasterBranch(), "main"),
                    (() => repository.IsOnDevelopBranch(), "develop"),
                    (() => repository.IsOnReleaseBranch(), "release"),
                    (() => repository.IsOnHotfixBranch(), "hotfix")
                };

            return new Dictionary<string, string>
                   {
                       ["repo_provider"] = providers.FirstOrDefault(x => x.Item1.Invoke()).Item2,
                       ["repo_branch"] = branches.FirstOrDefault(x => x.Item1.Invoke()).Item2,
                       ["repo_url"] = repository.SshUrl?.GetSHA256Hash().Substring(startIndex: 0, length: 6),
                       ["repo_commit"] = repository.Commit?.GetSHA256Hash().Substring(startIndex: 0, length: 6)
                   };
        }

        private static IDictionary<string, string> GetBuildProperties(INukeBuild build)
        {
            var startTimeString = EnvironmentInfo.Variables.GetValueOrDefault(Constants.GlobalToolStartTimeEnvironmentKey);
            var compileTime = startTimeString != null
                ? DateTime.Now.Subtract(DateTime.Parse(startTimeString))
                : default(TimeSpan?);

            return new Dictionary<string, string>
                   {
                       ["compile_time"] = compileTime?.TotalSeconds.ToString("F0"),
                       ["target_framework"] = EnvironmentInfo.Framework.ToString(),
                       ["host"] = GetTypeName(build.Host),
                       ["build_type"] = build.BuildProjectFile != null ? "Project" : "Global Tool",
                       ["num_targets"] = build.ExecutableTargets.Count.ToString(),
                       ["num_custom_extensions"] = build.BuildExtensions.Select(x => x.GetType()).Count(IsCustomType).ToString(),
                       ["num_custom_components"] = build.GetType().GetInterfaces().Count(IsCustomType).ToString(),
                       ["num_partitioned_targets"] = build.ExecutableTargets.Count(x => x.PartitionSize.HasValue).ToString(),
                       ["num_secrets"] = ValueInjectionUtility.GetParameterMembers(build.GetType(), includeUnlisted: true)
                           .Count(x => x.HasCustomAttribute<SecretAttribute>()).ToString(),
                       ["config_generators"] = build.GetType().GetCustomAttributes<ConfigurationAttributeBase>()
                           .Select(GetTypeName).Distinct().OrderBy(x => x).JoinCommaSpace(),
                       ["build_components"] = build.GetType().GetInterfaces().Where(x => IsCommonType(x) && x != typeof(INukeBuild))
                           .Select(GetTypeName).Distinct().OrderBy(x => x).JoinCommaSpace()
                   };
        }

        private static IDictionary<string, string> GetTargetProperties(INukeBuild build, ExecutableTarget target)
        {
            return new Dictionary<string, string>
                   {
                       ["target_name"] = target.Name,
                       ["target_duration"] = target.Duration.TotalSeconds.ToString("F0"),
                       ["target_current_partition"] = build.Partition.Part.ToString(),
                       ["target_total_partitions"] = build.Partition.Total.ToString()
                   };
        }

        private static IDictionary<string, string> GetGeneratorProperties(Type hostType, string generatorId)
        {
            return new Dictionary<string, string>
                   {
                       ["generator_host"] = GetTypeName(hostType),
                       ["generator_id"] = generatorId.GetSHA256Hash().Substring(startIndex: 0, length: 6)
                   };
        }

        private static bool IsCommonType(Type type)
        {
            return type.Assembly == typeof(NukeBuild).Assembly;
        }

        private static bool IsCustomType(Type type)
        {
            return !IsCommonType(type);
        }

        private static string GetTypeName(Type type)
        {
            return IsCommonType(type)
                ? type.Name.TrimEnd(nameof(Attribute))
                : type.Descendants(x => x.BaseType).FirstOrDefault(IsCommonType) is { } commonType
                    ? $"{GetTypeName(commonType)} (Custom)"
                    : "<Custom>";
        }

        private static string GetTypeName(object obj)
        {
            return GetTypeName(obj.GetType());
        }
    }
}
